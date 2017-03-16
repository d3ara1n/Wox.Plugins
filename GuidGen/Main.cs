using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Wox.Plugin;

namespace GuidGen
{
    public class Main : IPlugin
    {
        Dictionary<string, Func<string, string>> Switchers = new Dictionary<string, Func<string, string>>();
        
        public void Init(PluginInitContext context)
        {
            Switchers.Add("-u", s => s.ToUpper());
            Switchers.Add("-l", s => s.ToLower());
            Switchers.Add("-b", s => string.Format("{{{0}}}", s));
            Switchers.Add("-b1", s => string.Format("({0})", s));
            Switchers.Add("-b2", s => string.Format("[{0}]", s));
            Switchers.Add("-n", s => s.Replace("-", ""));
        }

        public List<Result> Query(Query query)
        {
            string str = Guid.NewGuid().ToString().ToLower();
            List<Result> results = new List<Result>();
            List<string> paras;
            if(string.IsNullOrEmpty(query.Search))
            {
                paras = new List<string>();
            }else
            {
                paras = query.Search.Split(' ').Select(line => line.Trim()).ToList();
            }
            str = Pick(paras,str);
            results.Add(new Result()
            {
                Title = "Guid Generator",
                SubTitle = "Click to copy: " + str,
                Action = c =>
                {
                    try
                    {
                        Clipboard.SetText(str);
                        return true;
                    }
                    catch (ExternalException e)
                    {
                        MessageBox.Show("复制到剪贴板失败: \n" + e.ToString(),"失败");
                        return false;
                    }

                },
                IcoPath = "app.png"
            });
            if(query.Search.Contains("-h"))
            {
                results.Add(new Result()
                {
                    Title = "Guid Generator|帮助",
                    SubTitle = "-h 帮助;-u 大写;-l 小写;-b 花括号;-b1 小括号;-b2 中括号;-n 去掉'-'符号",
                    IcoPath = "app.png"
                });
            }
            return results;
        }
        private string Pick(List<String> paras,string org)
        {
            string result = org;
            foreach(string par in paras)
            {
                if(Switchers.ContainsKey(par))
                {
                    result = Switchers[par].Invoke(result);
                }
            }
            return result;
        }
    }
}
