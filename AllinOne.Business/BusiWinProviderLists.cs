using AllinOne.Entity;
using AllinOne.Entity.ViewModel;
using AllinOne.Repository;
using AllinOne.WebSpider;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace AllinOne.Business
{
    public class BusiWinProviderLists
    {
        private WinProviderRepository winProviderRepository = new WinProviderRepository();

        public bool BusiInsertProviderInfo(WinProviderList winProviderList)
        {
            return winProviderRepository.RepoInsertProviderInfo(winProviderList);
        }

        public bool BusiUpdateProviderInfo(WinProviderList winProviderList)
        {
            return winProviderRepository.RepoUpdateProviderInfo(winProviderList);
        }

        public bool BusiDeleteProviderInfo(int? id)
        {
            return winProviderRepository.RepoDeleteProviderInfo(id);
        }

        public List<WinProviderList> BusiGetAllProviderInfo()
        {
            return winProviderRepository.RepoGetAllProviderInfo();
        }

        public WinProviderList BusiGetOneProviderInfo(int? id)
        {
            return winProviderRepository.RepoGetOneProviderInfo(id);
        }

        public Dictionary<string, string> InitSpider(RequestOptions options)
        {
            string HTML = Spider.RequestAction(options);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(HTML);
            HtmlNode node = document.DocumentNode.SelectSingleNode(options.winProviderList.Xpath);
            string rawInnerHtml = node.InnerHtml;

            string[] filter = rawInnerHtml.Split('{')[rawInnerHtml.Split('{').Length - 1].Split('}')[0].Replace("\n", "").Split(';');

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

        public RESTfulResult BusiInsertProviderStructure(int id, Dictionary<string, string> dic)
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
                winProviderRepository.RepoDeleteStructuresInfo(id);
            }

            if (winProviderRepository.RepoInsertStructuresInfo(WinProviderStructures))
            {
                winProviderRepository.RepoUpdateReload(id);
                return new RESTfulResult { StatusCode = 200, Succeeded = true, Data = WinProviderStructures, Message = " 获取成功！" };
            }
            return new RESTfulResult { StatusCode = 404, Succeeded = false, Data = "", Message = "数据库插入异常！" };
        }
    }
}
