using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TW.DataLayer;
using TW.Models;
using TW.Utility;

namespace TW.DataLayerSql
{
    public class SqlProjectGalleryProvider : IProjectGalleryProvider
    {
        public List<ProjectGallery> GetAllProjectGallery()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetAllProjectGallery, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<ProjectGallery> galleryList = new List<ProjectGallery>();
                    galleryList = UtilityManager.DataReaderMapToList<ProjectGallery>(dataReader);
                    return galleryList;
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
        public List<ProjectGallery> GetAllProjectGalleriesByProjectId(int projectId)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetAllProjectGalleriesByProjectId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProjectId", projectId));
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    List<ProjectGallery> galleryList = new List<ProjectGallery>();
                    galleryList = UtilityManager.DataReaderMapToList<ProjectGallery>(dataReader);
                    return galleryList;
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

        public ProjectGallery GetGalleryById(int Id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetProjectGalleryById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));
                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    ProjectGallery gallery = new ProjectGallery();
                    gallery = UtilityManager.DataReaderMap<ProjectGallery>(dataReader);
                    return gallery;
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
        public ProjectGallery GetProjectGalleryById(long Id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.GetProjectGalleryById, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", Id));

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    ProjectGallery gallery = new ProjectGallery();
                    gallery = UtilityManager.DataReaderMap<ProjectGallery>(reader);
                    return gallery;
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

        public long InsertProjectGallery(ProjectGallery gallery)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.InsertProjectGallery, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnValue = new SqlParameter("@" + "Id", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnValue);
                foreach (var item in gallery.GetType().GetProperties())
                {
                    if (item.Name != "Id")
                    {
                        string name = item.Name;
                        var value = item.GetValue(gallery, null);

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
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return id;
        }

        public bool UpdateProjectGallery(ProjectGallery gallery)
        {
            bool isUpdate = true;

            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.UpdateProjectGallery, connection);
                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in gallery.GetType().GetProperties())
                {
                    string name = item.Name;
                    var value = item.GetValue(gallery, null);
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

        public bool DeleteProjectGallery(long Id)
        {
            bool isDelete = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoreProcedure.DeleteProjectGallery, connection);
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
