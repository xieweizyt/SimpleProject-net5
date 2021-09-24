using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_net5.ReadAppsetting
{
    public class ReadAppSettingSimple
    {
        public static void Read(IConfiguration _configuration)
        {
            string id = _configuration["ID"];
        }


        public static void ReadByBuild(IConfiguration _configuration)
        {
            ConfigEntity configEntity = new ConfigEntity();
            _configuration.Bind("Entity", configEntity);
        }
    }
}
