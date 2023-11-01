using Authentication.Domain.Core.Interfaces;
using Authentication.Domain.Core.Models;
using Authentication.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Authentication.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected AuthenticationOrganizationContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(AuthenticationOrganizationContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            try
            {
                DbSet.Add(obj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<TEntity> FindAll(params string[] includes)
        {
            var query = DbSet.AsNoTracking();
            query = Includes(query, includes);

            var retorno = query.ToList();

            return retorno;
        }

        public IEnumerable<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            var query = DbSet.AsNoTracking().Where(predicate);
            query = Includes(query, includes);

            return query.ToList();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            var query = DbSet.AsNoTracking().Where(predicate);
            query = Includes(query, includes);

            return query.FirstOrDefault();
        }

        public TEntity GetById(int id, params string[] includes)
        {
            var query = DbSet.AsNoTracking().Where("Id == @0", id);
            query = Includes(query, includes);

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            var obj = GetById(id);
            obj.Removed = true;
            Update(obj);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        IQueryable<TEntity> Includes(IQueryable<TEntity> query, params string[] includes)
        {
            if (includes != null)
            {
                foreach (var item in includes)
                    query = query.Include(item);
            }

            return query;
        }

        protected object ConvertTableToObject(KeyValuePair<DataTable, string> retorno)
        {
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;

            foreach (DataRow row in retorno.Key.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in retorno.Key.Columns)
                    childRow.Add(col.ColumnName, row[col]);

                parentRow.Add(childRow);
            }

            return parentRow;
        }

        protected KeyValuePair<int, string> ExecuteNonQuery(string procedure, Dictionary<string, object> parameters = null)
        {
            KeyValuePair<int, string> retorno;

            try
            {
                Db.Database.OpenConnection();
                var command = Db.Database.GetDbConnection().CreateCommand();
                command.CommandTimeout = 240;
                command.CommandText = procedure;
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, object> item in parameters)
                    command.Parameters.Add(new SqlParameter(item.Key, item.Value));

                retorno = new KeyValuePair<int, string>(command.ExecuteNonQuery(), "");
            }
            catch (SqlException ex)
            {
                retorno = new KeyValuePair<int, string>(0, ex.Message);
            }
            catch (ApplicationException ex)
            {
                retorno = new KeyValuePair<int, string>(0, ex.Message);
            }
            catch (Exception ex)
            {
                retorno = new KeyValuePair<int, string>(0, ex.Message);
            }

            return retorno;
        }
        protected KeyValuePair<DataTable, string> GetDataTable(string procedure, Dictionary<string, object> parameters = null)
        {
            KeyValuePair<DataTable, string> retorno;
            var dataTable = new DataTable();

            try
            {
                Db.Database.OpenConnection();
                var command = Db.Database.GetDbConnection().CreateCommand();
                command.CommandTimeout = 600;
                command.CommandText = procedure;
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> item in parameters)
                    {
                        var ehData = typeof(DateTime).Name == item.GetType().Name;
                        if (ehData)
                        {
                            command.Parameters.Add(new SqlParameter(item.Key, (string)item.Value));
                        }
                        command.Parameters.Add(new SqlParameter(item.Key, item.Value));
                    }
                }

                dataTable.Load(command.ExecuteReader());

                retorno = new KeyValuePair<DataTable, string>(dataTable, "");
            }
            catch (SqlException ex)
            {
                retorno = new KeyValuePair<DataTable, string>(dataTable, ex.Message);
            }
            catch (ApplicationException ex)
            {
                retorno = new KeyValuePair<DataTable, string>(dataTable, ex.Message);
            }
            catch (Exception ex)
            {
                retorno = new KeyValuePair<DataTable, string>(dataTable, ex.Message);
            }

            return retorno;
        }
    }
}
