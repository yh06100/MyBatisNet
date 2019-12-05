using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.Common;
using IBatisNet.Common.Logging;
using IBatisNet.Common.Logging.Impl;
using log4net;
using log4net.Config;
using System.IO;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log4net.config"));
            //SelectYUNHO();
            SelectGRADE();
            Console.Read();
        }

        public static ISqlMapper EntityMapper
        {
            get
            {
                try
                {
                    ISqlMapper mapper = Mapper.Instance();
                    //mapper.DataSource.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    return mapper;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string executeFunction()
        {

            ISqlMapper mapper = EntityMapper;
            string str = mapper.QueryForObject<string>("FindPageId", "Footer");
            return str;
        }

        public static void SelectYUNHO()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass1 testVo = new MyClass1();
            IList<ConsoleApplication1.MyClass1> resultList = mapper.QueryForList<MyClass1>("SelectTable", testVo);

            for (int x = 0; x < resultList.Count; x++)
            {
                Console.WriteLine(resultList[x].C1);
                Console.WriteLine(resultList[x].C2);
                Console.WriteLine(resultList[x].C3);
                Console.WriteLine(resultList[x].C4);
            }

        }


        public static void SelectGRADE()
        {
            ISqlMapper mapper = EntityMapper;
            ConsoleApplication1.Class.MyClass1 testVo = new ConsoleApplication1.Class.MyClass1();
            IList<ConsoleApplication1.Class.MyClass1> resultList = mapper.QueryForList<ConsoleApplication1.Class.MyClass1>("SelectGRADE", testVo);

            for (int x = 0; x < resultList.Count; x++)
            {
                Console.WriteLine(resultList[x].C_NAME + resultList[x].C_KOREAN + resultList[x].C_ENGLISH + resultList[x].C_MATH
                     + resultList[x].C_SCIENCE);
            }

        }
    }
}
