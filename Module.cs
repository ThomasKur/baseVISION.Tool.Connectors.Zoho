using System;

using baseVISION.Tool.Connectors.Zoho.Contracts;
using baseVISION.Tool.Connectors.Zoho.Model;
using RestSharp;
namespace baseVISION.Tool.Connectors.Zoho
{
    public class Module<T> where T : IZohoRecord
    {
        ZohoClient client = null;
        string module = "";
        public Module(ZohoClient client, string module)
        {
            this.client = client;
            this.module = module;
        }
        public Result<T> List(int page = 1, SortOrder order = SortOrder.asc, string sortBy = "Company")
        {
            RestRequest r = new RestRequest("crm/v2/" + module, Method.Get);
            r.AddQueryParameter("page", page.ToString());
            if (!String.IsNullOrWhiteSpace(sortBy))
            {
                r.AddQueryParameter("sort_order", order.ToString());
                r.AddQueryParameter("sort_by", sortBy);
            }
            return client.Execute<Result<T>>(r);
        }
        public Result<T> Search(string keyword, int page = 1)
        {
            RestRequest r = new RestRequest("crm/v2/" + module + "/search", Method.Get);
            r.AddQueryParameter("word", keyword);
            r.AddQueryParameter("page", page.ToString());
            return client.Execute<Result<T>>(r);
        }
        public Result<T> SearchByCriteria(string criteria, int page = 1)
        {
            RestRequest r = new RestRequest("crm/v2/" + module + "/search", Method.Get);
            r.AddQueryParameter("criteria", criteria);
            r.AddQueryParameter("page", page.ToString());
            return client.Execute<Result<T>>(r);
        }
        public Result<T> Get(string id)
        {
            RestRequest r = new RestRequest("crm/v2/" + module + "/{id}", Method.Get);
            r.AddUrlSegment("id", id);
            return client.Execute<Result<T>>(r);
        }
        public Result<ActionResult> Add(T record)
        {
            RestRequest r = new RestRequest("crm/v2/" + module, Method.Post);
            
            Input<T> i = new Input<T>();
            i.Data.Add(record);
            i.trigger = new System.Collections.Generic.List<string>();
            i.trigger.Add("workflow");
            r.AddJsonBody(i);
            return client.Execute<Result<ActionResult>>(r);
        }
        public Result<ActionResult> Update(T record)
        {
            RestRequest r = new RestRequest("crm/v2/" + module + "/{id}", Method.Put);
            r.AddUrlSegment("id", record.Id);
            Input<T> i = new Input<T>();
            i.Data.Add(record);
            i.trigger = new System.Collections.Generic.List<string>();
            i.trigger.Add("workflow");
            r.AddJsonBody(i);
            return client.Execute<Result<ActionResult>>(r);
        }
    }
}
