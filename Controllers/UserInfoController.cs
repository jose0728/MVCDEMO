using MVCDEMO.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDEMO.Controllers
{
    /// <summary>
    /// Model（模型）是应用程序中用于处理应用程序数据逻辑的部分。
    ///通常模型对象负责在数据库中存取数据。

    ///View（视图）是应用程序中处理数据显示的部分。
    ///通常视图是依据模型数据创建的。

    ///Controller（控制器）是应用程序中处理用户交互的部分。
    ///通常控制器负责从视图读取数据，控制用户输入，并向模型发送数据
    /// </summary>
    public class UserInfoController : Controller
    {
        public const string constr = @"server=192.168.33.128;port=3306;database=demo;uid=root;password=Asdf@123;character set=utf8mb4;";

        // GET: UserInfoList
        public ActionResult Index()
        {
            string str = "select * from userinfo";
            var ds = Query(str, 10);
            List<UserInfo> userInfoList = new List<UserInfo>();//新建一个集合来储存数据
            DataTable dt;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                userInfoList = DataTableToList(dt);
            }

            //ViewData是一种字典集合数据，是“视图基类”和“控制器基类”的属性
            //常见的用法是在控制器中写入数据，在视图中读取数据
            //ViewData的value可以存放任意数据类型的数据，因此使用时需要强制转换
            ViewData["userinfolist"] = userInfoList;


            return View();
        }

        // GET: UserInfo
        public ActionResult Detail(string userId)
        {
            string str = "select * from userinfo where UserId = @UserId";
            MySqlParameter[] paras = { new MySqlParameter("@UserId", userId) };
            var ds = Query(str, paras);
            UserInfo userInfo = new UserInfo();//新建一个集合来储存数据
            DataTable dt;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                userInfo = DataTableToList(dt)[0];
            }

            //ViewBag是dynamic类型的对象，同样也是“视图基类”和“控制器基类”的属性
            //好处：使用灵活方便
            //特点：ViewBag其实是对ViewData数据的包装，使用ViewData保存数据可以使用ViewBag读取，反之也是如此
            //实际开发中最好选择其中一种使用，建议使用ViewBag
            ViewBag.User = userInfo;

            //TempData是一种字典对象，也能用于从“控制器到视图的数据传递”，和ViewData类似
            //TempData还能实现“不同请求之间”的数据传递，跨请求数据传递
            //TempData保存数据的机制是Session，但又不完全和Session相同
            //TempData保存数据后，如果被使用，就会被清除，因此后面的请求将不能再次使用
            //TempData保存数据后，如果没有被使用，则他保存的时间是Session的生命周期
            TempData["userinfo"] = userInfo;

            //return View();
            return View(userInfo);
        }

        //ViewData  适合传递单个数据，需要类型转换
        //ViewBag	适合传递单个数据，不需要类型转换
        //TempData 主要用来跨多个动作方法传递数据
        //View()+Model	适合传递模型数据，不需要类型转换

        #region 数据库封装
        public DataSet Query(string sql, params MySqlParameter[] paras)
        {
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand())
                {
                    PrepareCommand(mySqlCommand, conn, null, sql, paras);
                    DataSet dataSet = new DataSet();
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                    try
                    {
                        mySqlDataAdapter.Fill(dataSet, "ds");
                        mySqlCommand.Parameters.Clear();
                        return dataSet;
                    }
                    finally
                    {
                        ((IDisposable)(object)mySqlDataAdapter)?.Dispose();
                    }
                }
            }
        }

        private void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] paras)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.CommandType = CommandType.Text;
            if (paras == null)
            {
                return;
            }

            foreach (MySqlParameter mySqlParameter in paras)
            {
                if ((mySqlParameter.Direction == ParameterDirection.InputOutput || mySqlParameter.Direction == ParameterDirection.Input) && mySqlParameter.Value == null)
                {
                    mySqlParameter.Value = DBNull.Value;
                }

                cmd.Parameters.Add(mySqlParameter);
            }
        }

        public DataSet Query(string sql, int timeout)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(constr))
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, mySqlConnection);
                try
                {
                    DataSet dataSet = new DataSet();
                    mySqlConnection.Open();
                    mySqlDataAdapter.SelectCommand.CommandTimeout = timeout;
                    mySqlDataAdapter.Fill(dataSet, "ds");
                    return dataSet;
                }
                finally
                {
                    ((IDisposable)(object)mySqlDataAdapter)?.Dispose();
                }
            }
        }

        private List<UserInfo> DataTableToList(DataTable dt)
        {
            List<UserInfo> modelList = new List<UserInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                UserInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new UserInfo();
                    model.EnterpriseId = dt.Rows[n]["EnterpriseId"].ToString();
                    model.UserId = dt.Rows[n]["UserId"].ToString();
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.Position = dt.Rows[n]["Position"].ToString();
                    if (dt.Rows[n]["Active"] != DBNull.Value)
                    {
                        model.Active = (bool)dt.Rows[n]["Active"];
                    }
                    model.Avatar = dt.Rows[n]["Avatar"].ToString();
                    if (dt.Rows[n]["UserType"].ToString() != "")
                    {
                        model.UserType = short.Parse(dt.Rows[n]["UserType"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
    }
}