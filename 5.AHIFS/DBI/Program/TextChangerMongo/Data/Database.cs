using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Core;
using MongoDB.Bson;

namespace Data
{
    public class Database
    {

        static IMongoDatabase db;

        public static void Connect()
        {
            try
            {
                var connectionString = "mongodb://127.0.0.1:27017";
                var client = new MongoClient(connectionString);
                db = client.GetDatabase("myDb");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void InsertFile(File newFile)
        {
            IMongoCollection<File> collection;

            try
            {
                collection = db.GetCollection<File>("Files");
                collection.InsertOne(newFile);
            }
            catch (Exception ex)
            {
                throw new Exception("Error at inserting");
            }
        }

        public static List<File> getAllFiles()
        {
            IMongoCollection<File> collection;
            List<File> allFiles;

            try
            {
                collection = db.GetCollection<File>("Files");
                allFiles = collection.Find("{}").ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("Error at getting all files");
            }

            return allFiles;
        } 

        public static String getFileContent(File f)
        {
            IMongoCollection<File> collection;
            List<File> foundFiles;
            String content = null;

            try
            {
                collection = db.GetCollection<File>("Files");
                foundFiles = collection.Find(x => x._id == f._id).ToList();

                if(foundFiles.Count <= 0)
                {
                    throw new Exception("");
                }

                content = foundFiles[0].fileContent;
            }
            catch(Exception ex)
            {
                throw new Exception("Error at loading content");
            }

            return content;
        }

        public static void updateFileContent(File currentFile, String newText)
        {
            IMongoCollection<File> collection;
           
            try
            {
                collection = db.GetCollection<File>("Files");
                var updoneresult = collection.UpdateOneAsync(
                                Builders<File>.Filter.Eq("_id", currentFile._id),
                                Builders<File>.Update.Set("fileContent", newText));
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        public static List<File> findText(string TextToFind)
        {
            IMongoCollection<File> collection;
            List<File> foundFiles;
            try
            {
                collection = db.GetCollection<File>("Files");
                collection.Indexes.CreateOne(Builders<File>.IndexKeys.Text(x => x.fileContent));

                foundFiles = collection.Find(Builders<File>.Filter.Text(TextToFind)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }

            return foundFiles;
        }
    }
}
