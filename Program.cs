using System;
using System.IO;
using System.Collections;
namespace ClearWorkSpace
{
    public class Program
    {
      
       public static void Main(string[] args)
        {
            DateTime thisDay = DateTime.Today;
            string check = "C:\\"+"Users\\leonid2223\\Desktop\\";
            DirectoryInfo dirInfo = new DirectoryInfo(check+"\\"+thisDay.ToString("d"));
if (!dirInfo.Exists)
{
    dirInfo.Create();
}
            Console.WriteLine(check);
         string Dirs = dirInfo.ToString();
          Console.WriteLine("EROOR "+Dirs);
                ProcessDirectory(check);
                 Console.WriteLine("da"+check);
                ProcessFile(check);
                DirectoryInfo dir = new DirectoryInfo(check);
            foreach (var item in dir.GetDirectories())
            {
                if(item.Name != thisDay.ToString("d")){

DirectoryInfo newDir = new DirectoryInfo(check+"\\"+thisDay.ToString("d")+"\\"+item.Name);
if (!newDir.Exists)
{
    newDir.Create();
}
CopyFolder(item.ToString(),check+"\\"+thisDay.ToString("d")+"\\"+item.Name);
DirectoryInfo lostDir = new DirectoryInfo(check+"\\"+item.Name);
 DeleteDirectory(lostDir.FullName);
                }
            }
           
           
        }
          
        public static void ProcessDirectory(string patch){
string[] files = Directory.GetFiles(patch);
foreach(string fileName in files){
    string ext = Path.GetExtension(fileName);
Console.WriteLine(ext);
            ProcessFile(fileName);
            Console.WriteLine("FILE NAME + "+Path.GetFileName(fileName));
          if((ext != ".lnk") || (ext !=".ini")){
              Console.WriteLine("OK , YES");
              string dirInfo_ = "C:\\"+"Users\\leonid2223\\Desktop\\"+DateTime.Today.ToString("d");
File.Move(fileName,dirInfo_+"\\"+Path.GetFileName(fileName),true);
Console.WriteLine(dirInfo_+Path.GetFileName(fileName));
          }
}


        //     string [] subdirectoryEntries = Directory.GetDirectories(patch);
        // foreach(string subdirectory in subdirectoryEntries)
        //     ProcessDirectory(subdirectory);
        }
         public static void ProcessFile(string path) 
    {
        Console.WriteLine("Processed file '{0}'.", path);	    
    }
    static public void CopyFolder(string sourceFolder, string destFolder )
{
    if (!Directory.Exists( destFolder ))
        Directory.CreateDirectory( destFolder );
    string[] files = Directory.GetFiles( sourceFolder );
    foreach (string file in files)
    {
        string name = Path.GetFileName( file );
        string dest = Path.Combine( destFolder, name );
        File.Copy( file, dest ,true);
    }
    string[] folders = Directory.GetDirectories( sourceFolder );
    foreach (string folder in folders)
    {
       string name = Path.GetFileName( folder );
       string dest = Path.Combine( destFolder, name );
        CopyFolder( folder, dest );
    }
}
public static void DeleteDirectory(string target_dir)
{
    string[] files = Directory.GetFiles(target_dir);
    string[] dirs = Directory.GetDirectories(target_dir);

    foreach (string file in files)
    {
        File.SetAttributes(file, FileAttributes.Normal);
        File.Delete(file);
    }

    foreach (string dir in dirs)
    {
        DeleteDirectory(dir);
    }

    Directory.Delete(target_dir, true);
}
}
    }
