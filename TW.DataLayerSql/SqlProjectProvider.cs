using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TW.DataLayer;
using TW.Models;
using TW.Utility;

namespace TW.DataLayerSql
{
    public class SqlProjectProvider : IProjectProvider
    {
        public List<Project> GetAllProject()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetAllProjects, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Project> projectList = new List<Project>();
                    projectList = UtilityManager.DataReaderMapToList<Project>(dataReader);
                    return projectList;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }

                finally
                {
                    connection.Close();
                }
            }
        }
        public List<Project> GetAllProjectsByCategoryId(int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetAllProjectsByCategoryId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<Project> projectList = new List<Project>();
                    projectList = UtilityManager.DataReaderMapToList<Project>(dataReader);
                    return projectList;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }

                finally
                {
                    connection.Close();
                }
            }
        }
        public Project GetProjectById(long Id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetProjectsById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Project project = new Project();
                    project = UtilityManager.DataReaderMap<Project>(reader);
                    return project;
                }
                catch (Exception e)
                {
                    throw new Exception("Exception retrieving reviews. " + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public long InsertProject(Project project)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.InsertProjects, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var projects in project.GetType().GetProperties())
                {
                    if (projects.Name != "Id")
                    {
                        string name = projects.Name;
                        var value = projects.GetValue(project, null);

                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@Id"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Execption Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public bool UpdateProject(Project projects)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UpdateProjects, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var project in projects.GetType().GetProperties())
                {
                    string name = project.Name;
                    var value = project.GetValue(projects, null);
                    command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isUpdate = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isUpdate;
        }

        public bool DeleteProject(long Id)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DeleteProject, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    isDelete = false;
                    throw new Exception("Exception Updating Data." + e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return isDelete;
        }
    }
}
