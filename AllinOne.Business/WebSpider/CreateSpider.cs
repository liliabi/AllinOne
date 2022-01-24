using AllinOne.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllinOne.WebSpider;
using HtmlAgilityPack;
using AllinOne.Repository;
using AllinOne.Entity.ViewModel;

namespace AllinOne.Business.WebSpider
{
    public class CreateSpider
    {
        private SpiderRepository spiderRepository = new SpiderRepository();
        public Dictionary<string, string> InitSpider(RequestOptions options)
        {
            Spider webSpider = new Spider();
            string HTML = webSpider.RequestAction(options);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(HTML);
            HtmlNode node = document.DocumentNode.SelectSingleNode("/html/body/div[2]/div/section/div/div[1]/main/pre[1]/code");
            string rawInnerHtml = node.InnerHtml;
            
            string[] filter = rawInnerHtml.Split('{')[rawInnerHtml.Split('{').Length -1].Split('}')[0].Replace("\n", "").Split(';');

            Dictionary<string, string> map = new Dictionary<string, string>();
            foreach (string filterStr in filter)
            {
                if (filterStr.Trim().Length > 0)
                {
                    string[] kv = filterStr.Trim().Split(' ');
                    map.Add(kv[kv.Length - 1], kv[0]);
                }

            }
            return map;
        }

        public RESTfulResult InsertToDb(int id, Dictionary<string, string> dic)
        {
            List<WinProviderStructure> WinProviderStructures = new List<WinProviderStructure>();
            foreach (var item in dic)
            {
                WinProviderStructure str = new WinProviderStructure();
                str.ID = id;
                str.ProviderType = item.Value;
                str.ProviderField = item.Key;
                WinProviderStructures.Add(str);

            }
            if (WinProviderStructures.Count > 0)
            {
                spiderRepository.DeleteServiceInfo(id);
            }

            if (spiderRepository.SaveServiceInfo(WinProviderStructures))
            {
                spiderRepository.UpdateReload(id);
                return new RESTfulResult { StatusCode = 200, Succeeded = true, Data = WinProviderStructures, Message = " 获取成功！" };
            }
            return new RESTfulResult { StatusCode = 404, Succeeded = false, Data = "", Message = "数据库插入异常！" };
        }
    }
}
