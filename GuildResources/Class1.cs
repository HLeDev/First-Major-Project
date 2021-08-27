using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildResources
{
    public interface CRUD //creating CRUD method
    {
        void create(GStorage obj);
        ICollection<GStorage> Read();
        void Update(decimal id, GStorage storageupdate);
        void Delete(GStorage obj);
        GStorage GetInformation(decimal id);
    }
    public class GuildStorageRepository : CRUD
    {
        GuildProjectEntities guildentities; //creating entity for sqldb entity
        public GuildStorageRepository()
        {
            guildentities = new GuildProjectEntities(); //making entities public for use in CRUD
        }
        public void create(GStorage obj)
        {
            guildentities.GStorages.Add(obj); //for adding/creating item
            guildentities.SaveChanges();
        }

        public void Delete(GStorage obj)
        {
            guildentities.GStorages.Remove(obj); //deleting an object
            guildentities.SaveChanges(); //save changes after deletion
        }

        public GStorage GetInformation(decimal id)
        {
            var gstorage = guildentities.GStorages.Find(id); //finding ID in guild storage
            return gstorage; //then return the id
        }

        public ICollection<GStorage> Read()
        {
            return guildentities.GStorages.ToList();
        }

        public ICollection<GStorage> Query(string querystring) //using query to select specific value to display
        {
            //var newstorage = guildentities.GStorages.SqlQuery("Select*From GStorage Where GuildID = 1")

            //rather than hard coding it, we'll just take inputs from XAML.
            var newstorage = guildentities.GStorages.SqlQuery(querystring);
            return newstorage.ToList();
        }

        public void Update(decimal id, GStorage storageupdate)
        {
            var stoupd = guildentities.GStorages.Find(id); //finding ID in storage
            stoupd.GSItemID = stoupd.GSItemID; //making new obj = storage information for updating
            stoupd.GSItemType = stoupd.GSItemType;
            stoupd.GSItemDescription = stoupd.GSItemDescription;
            stoupd.Qty = stoupd.Qty;
            stoupd.GuildID = stoupd.GuildID;
            guildentities.SaveChanges(); //once updates complete, save all changes
        }
    }
}
