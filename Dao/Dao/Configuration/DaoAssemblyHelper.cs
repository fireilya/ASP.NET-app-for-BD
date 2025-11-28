using System.Reflection;

namespace Dao.Configuration;

public static class DaoAssemblyHelper
{
    public static Assembly GetDaoAssembly() => Assembly.GetExecutingAssembly();
}