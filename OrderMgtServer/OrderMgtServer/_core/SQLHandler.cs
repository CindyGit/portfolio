using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace OrderMgtServer._core
{
    public class SQLHandler
    {
        
        #region 公用屬性
        public string _sql;
        public SqlParameterCollection _param;
        /// <summary>
        /// 預設值CommandType.Text
        /// </summary>
        public CommandType _type;
        /// <summary>
        /// DBConntectionString
        /// 預設值 AppConfig.DBConntectionString
        /// </summary>
        public string _conn;
        public string _errMsg;
        public ArrayList _sqlary;
        public ArrayList _paramary;
        #endregion

        #region 建構子
        public SQLHandler()
        {
            _sql = string.Empty;
            _type = CommandType.StoredProcedure;
            _conn = AppConfig.DBConnStr;
            _param = (SqlParameterCollection)typeof(SqlParameterCollection).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null).Invoke(null);
            _errMsg = string.Empty;
            _sqlary = new ArrayList();
            _paramary = new ArrayList((SqlParameterCollection)typeof(SqlParameterCollection).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null).Invoke(null));
        }
        #endregion

        #region 公用涵式
        public DataTable ExecuteGetDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = _type;
                        cmd.CommandText = _sql;
                        foreach (SqlParameter param in _param)
                            cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                        using (SqlDataAdapter oda = new SqlDataAdapter(cmd))
                        {
                            oda.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errMsg = ex.Message;
                _core.Common.WriteLogFile("ExecuteGetDataTable_ERROR:" + ex.Message + "<" + _sql + ">");
            }

            return dt;
        }

        public DataSet ExecuteGetDataSet()
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = _type;
                        cmd.CommandText = _sql;
                        foreach (SqlParameter param in _param)
                            cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                        using (SqlDataAdapter oda = new SqlDataAdapter(cmd))
                        {
                            oda.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errMsg = ex.Message;
                _core.Common.WriteLogFile("ExecuteGetDataSet_ERROR:" + ex.Message + "<" + _sql + ">");
            }
            return ds;
        }

        public bool ExecuteNonQuery()
        {
            bool bRet = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandType = _type;
                        cmd.CommandText = _sql;
                        foreach (SqlParameter param in _param)
                            cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                        cmd.ExecuteNonQuery();
                        bRet = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _errMsg = ex.Message;
                _core.Common.WriteLogFile("ExecuteNonQuery_ERROR:" + ex.Message);
            }
            return bRet;
        }

        public object ExecuteScalar()
        {
            object obj = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.Connection = conn;
                        cmd.CommandType = _type;
                        cmd.CommandText = _sql;
                        foreach (SqlParameter param in _param)
                            cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                        obj = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                _errMsg = ex.Message;
            }
            return obj;
        }

        public bool ExecuteTransaction()
        {
            bool bRet = false;
            using (SqlConnection conn = new SqlConnection(_conn))
            {
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (SqlParameterCollection _param in _paramary)
                            ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        _errMsg = ex.Message;
                    }
                }
            }

            return bRet;
        }
        #endregion




        #region 直接執行sql指令
        public DataTable SQLExecute(string strSQL)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_conn))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strSQL;
                        using (SqlDataAdapter oda = new SqlDataAdapter(cmd))
                        {
                            oda.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errMsg = ex.Message;
            }

            return dt;
        }

        #endregion
    }
}