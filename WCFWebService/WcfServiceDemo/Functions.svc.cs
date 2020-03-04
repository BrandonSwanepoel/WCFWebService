using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WcfServiceDemo
{
    public class Functions : IFunctions
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString);
        public DataSet GetUserDetails()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select * From tblEmployee", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        public DataSet CountUsers()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("CountAllUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.BeginExecuteNonQuery();
            con.Close();
            return ds;
        }
        public double Count(string parameter)
        {
            double[] finalArray = new double[parameter.Length];
            double result = 0;
            int j = 0;
            int s = 0;
            for (int k = 0; k < parameter.Length; k++)
            {
                j = 0;
                char[] tmp = new char[parameter.Length];
                while (parameter[k] != ',' && parameter[k] != '\0')
                {
                    if (parameter[k] != '\0')
                    {
                        tmp[j] = parameter[k];
                        j++;
                    }
                    k++;
                    if (k > (parameter.Length) - 1)
                    {
                        break;
                    }
                }
                string charstr = new string(tmp);
                if (tmp[0] != '\0')
                {
                    finalArray[s] = Convert.ToDouble(charstr);
                    s++;
                }
            }
            for (int i = 0; i < finalArray.Length; i++)
            {
                result += finalArray[i];
            }
            return result;
        }
        public double Even(string parameter)
        {
            double add, n;
            n = Convert.ToDouble(parameter);

            if (n == 0)
                return 0;
            add = n % 2;

            return add += n;
        }
        public double GreatestCommonDenominator(string parameter)
        {
            var finalArray = new List<double>();
            double minimumParameter;
            int j = 0;
            for (int k = 0; k < parameter.Length; k++)
            {
                j = 0;
                char[] tmp = new char[parameter.Length];
                while (parameter[k] != ',' && parameter[k] != '\0')
                {
                    if (parameter[k] != '\0')
                    {
                        tmp[j] = parameter[k];
                        j++;
                    }
                    k++;
                    if (k > (parameter.Length) - 1)
                    {
                        break;
                    }
                }
                string charstr = new string(tmp);
                if (tmp[0] != '0')
                {
                    finalArray.Add(Convert.ToDouble(charstr));
                }
            }
            minimumParameter = finalArray.Min();
            double result = GetGreatestDenominator(minimumParameter, finalArray);
            return result;
        }
        private double GetGreatestDenominator(double minimumParameter, List<double> x)
        {
            double defaultValue = -1;
            if (x.Count > 1)
            {
                for (double divide = minimumParameter; divide > 0; divide--)
                {
                    Boolean isDivide = true;
                    foreach (double y in x)
                    {
                        double yAsDouble = y;
                        if (yAsDouble >= Math.Pow(2, 53))
                        {
                            return -1;
                        }
                        if (yAsDouble < 0)
                        {
                            return -1;
                        }
                        if (Math.Floor(yAsDouble) % Math.Floor(divide) != 0)
                        {
                            isDivide = false;
                        }
                    }
                    divide = Math.Truncate(divide);
                    if (isDivide)
                    {
                        return divide;
                    }
                }
                return defaultValue;
            }
            return Math.Truncate(x[0]);
        }
        public double LeastCommonDenominator(string parameter)
        {
            var finalArray = new List<double>();
            int j = 0;
            for (int k = 0; k < parameter.Length; k++)
            {
                j = 0;
                char[] tmp = new char[parameter.Length];
                while (parameter[k] != ',' && parameter[k] != '\0')
                {
                    if (parameter[k] != '\0')
                    {
                        tmp[j] = parameter[k];
                        j++;
                    }
                    k++;
                    if (k > (parameter.Length) - 1)
                    {
                        break;
                    }
                }
                string charstr = new string(tmp);
                if (tmp[0] != '0')
                {
                    finalArray.Add(Convert.ToDouble(charstr));
                }
            }
            double result = GetLeastCommonDenominator(finalArray);
            return result;
        }
        private double GetLeastCommonDenominator(List<double> arr)
        {
            double defaultValue = -1;
            double maximumParameter = arr.Max();
            double searchLimit = Math.Pow(2, 53);

            if (arr.Count > 1)
            {
                for (double multiple = maximumParameter; multiple < searchLimit; multiple++)
                {
                    Boolean isMultiple = true;
                    foreach (double y in arr)
                    {
                        if (y >= Math.Pow(2, 53))
                        {
                            return -1;
                        }
                        if (y < 0)
                        {
                            return defaultValue;
                        }
                        if (y == 0)
                        {
                            return defaultValue;
                        }
                        if (Math.Floor(multiple) % Math.Floor(y) != 0)
                        {
                            isMultiple = false;
                        }
                    }
                    if (isMultiple)
                    {
                        return Math.Truncate(multiple);
                    }
                }
                return defaultValue;
            }
            return Math.Truncate(arr[0]);
        }
    }
}
