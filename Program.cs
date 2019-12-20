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
using ConsoleApplication1.Class;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log4net.config"));
            //SelectYUNHO();
            //SelectGRADE();

            //InsertINFO();
            //InsertTable();
            //SelectTable();
            //SelectINFO();
            //InsertSTUDENTS();
            //SelectSTUDENTS();

            InsertSTUDENT();
            SelectSTUDENT();
            InsertSCORE();
            SelectSCORE();

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

        public static void SelectTable()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass1 testVo = new MyClass1();
            IList<ConsoleApplication1.MyClass1> resultList = mapper.QueryForList<MyClass1>("SelectTable", testVo);

            for (int x = 0; x < resultList.Count; x++)
            {
                Console.WriteLine("{0},{1},{2},{3},{4}", resultList[x].C1, resultList[x].C2, resultList[x].C3, resultList[x].C4, resultList[x].C5);
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


        public static void SelectINFO()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass2 testVo = new MyClass2();
            IList<MyClass2> resultList = mapper.QueryForList<MyClass2>("SelectINFO", testVo);

            for (int x = 0; x < resultList.Count; x++)
            {
                Console.WriteLine(resultList[x].C_NAME + resultList[x].C_AGE + resultList[x].C_PHONE + resultList[x].C_SOCIAL_NUMBER);
            }
        }

        public static void InsertINFO()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass2 testVo = new MyClass2() {C_NAME = "JAMES", C_AGE ="100",C_PHONE ="010-0987-0123",C_SOCIAL_NUMBER = "001231-4567894" };
            mapper.Insert("InsertINFO", testVo);
        }

        public static void InsertTable()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass1 testVo = new MyClass1() { C1 = "JAMES", C2 = "ASD", C3 = "ARS", C4 = "BBQ" };
            mapper.Insert("InsertTable", testVo);
        }

        public static void SelectSTUDENTS()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass3 testVo = new MyClass3();
            IList<MyClass3> resultList = mapper.QueryForList<MyClass3>("SelectSTUDENTS", testVo);

            for (int x = 0; x < resultList.Count; x++)
            {
                Console.WriteLine(resultList[x].C_KOR_NAME + resultList[x].C_ENG_NAME + resultList[x].C_AGE);
            }
        }
        public static void InsertSTUDENTS()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass3 testVo = new MyClass3() { C_KOR_NAME = "윤호", C_ENG_NAME = "YUNHO", C_AGE = 30 };
            mapper.Insert("InsertSTUDENTS", testVo);
        }

        public static void SelectSTUDENT()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass4 testVo = new MyClass4();
            IList<MyClass4> resultList = mapper.QueryForList<MyClass4>("SelectSTUDENT", testVo);

            for (int x = 0; x < resultList.Count; x++)
            {
                Console.WriteLine(resultList[x].NUMBER + resultList[x].NAME + resultList[x].AGE + resultList[x].SEX);
            }
        }
        public static void InsertSTUDENT()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass4 testVo = new MyClass4() { NUMBER = "13-71019423", NAME = "OHYUNHO", AGE = "27", SEX = "MAN" };
            mapper.Insert("InsertSTUDENT", testVo);
        }
        public static void SelectSCORE()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass4 testVo = new MyClass4();
            IList<MyClass4> resultList = mapper.QueryForList<MyClass4>("SelectSCORE", testVo);

            for (int x = 0; x < resultList.Count; x++)
            {
                Console.WriteLine(resultList[x].NUMBER + resultList[x].KOREAN + resultList[x].ENGLISH + resultList[x].MATH
                    + resultList[x].SOCIAL + resultList[x].SCIENCE);
            }
        }
        public static void InsertSCORE()
        {
            ISqlMapper mapper = EntityMapper;
            MyClass4 testVo = new MyClass4() { NUMBER = "13-71019423", KOREAN = "10", ENGLISH = "20", MATH = "30" 
            , SOCIAL = "40", SCIENCE = "50"};
            mapper.Insert("InsertSCORE", testVo);
        }

    }
}