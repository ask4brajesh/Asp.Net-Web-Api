using Asp.Net_Web_Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Asp.Net_Web_Api.Controllers
{
    public class ValuesController : ApiController
    {
        SampleDBEntities1 dbo = new SampleDBEntities1();
        
        public IHttpActionResult GetAll()
        {
            var JsonData = string.Empty;

            try
            {
                var data = dbo.AGENTS.ToList();
                if (data != null)
                {
                    JsonData = JsonConvert.SerializeObject(data);
                }
                else
                {
                    JsonData = "No records found";
                }
            }
            catch (Exception ex)
            {
                JsonData = ex.Message;
            }

            return Ok(JsonData);

        }

        
        public IHttpActionResult Get(string id)
        {
            var jsonData = string.Empty;
            try
            {
                var data = dbo.AGENTS.Where(x => x.AGENT_CODE == id).FirstOrDefault();
                if (data != null)
                {
                    jsonData = JsonConvert.SerializeObject(data);
                }
                else {
                    jsonData = "No Records Found";
                }
            }
            catch (Exception ex) {
                jsonData = ex.Message;
            }
            return Ok(jsonData);
        }

        
        public IHttpActionResult Insert(AGENTS agent)
        {
            var JsonData = string.Empty;
            try
            {
                var data = dbo.AGENTS.Where(x => x.AGENT_NAME.ToUpper() == agent.AGENT_NAME.ToUpper()).FirstOrDefault();
                if (data != null)
                {
                    JsonData = "agent already exist";
                }
                else {
                    dbo.AGENTS.Add(agent);
                    dbo.SaveChanges();
                    JsonData = "record saved successfully";
                }
            }
            catch (Exception ex) {
                JsonData = ex.Message;
            }
            return Ok(JsonData);
        }

      
        public IHttpActionResult Update(AGENTS agent)
        {
            var jsonData = string.Empty;
            try
            {
                AGENTS data = dbo.AGENTS.Where(x => x.AGENT_CODE == agent.AGENT_CODE).FirstOrDefault();
                if (data != null) {
                    data.AGENT_NAME = agent.AGENT_NAME;
                    data.COMMISSION = agent.COMMISSION;
                    data.COUNTRY = agent.COUNTRY;
                    data.PHONE_NO = agent.PHONE_NO;
                    data.WORKING_AREA = agent.WORKING_AREA;
                    dbo.SaveChanges();
                    jsonData = "Record updated Successfully";
                }
            }
            catch (Exception ex) {
                jsonData = ex.Message;
            }
            return Ok(jsonData);
        }

       
        public IHttpActionResult Delete(string id)
        {
            var JsonData = string.Empty;
            try
            {
                var data = dbo.AGENTS.Where(x => x.AGENT_CODE == id).FirstOrDefault();
                if (data != null)
                {
                    dbo.AGENTS.Remove(data);
                    dbo.SaveChanges();
                    JsonData = "record deleted successfully";
                }
                else {
                    JsonData = "record not available";
                }
            }
            catch (Exception ex) {
                JsonData = ex.Message;
            }
            return Ok(JsonData);
        }
    }
}