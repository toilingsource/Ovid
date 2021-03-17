using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace Ovid.GitLabDocument
{
    public class MethodParamaters
    {
        public string Summary { get; set; }

        public Dictionary<string, string> Paramaters { get; set; } = new Dictionary<string, string>();
    }


    /// <summary>
    /// Small Console Application that is used to generate git lab wiki stub documentation 
    /// It uses a set of dotnet attributes to annotate classes that need to be documented. 
    /// Class UML diagrams and class information is created for each object. If the XML 
    /// comment documentation is passed then the runner attempts to add a table with comments
    /// to the class pages
    /// </summary>
    class Program
    {


        static string output { get; set; } = "output";
        static string DllPath { get; set; } = string.Empty;
        static bool runSilent { get; set; } = false;
        static bool useComments { get; set; } = false;
        static string commentFile { get; set; } = string.Empty;


        static Queue<string> pointers = new Queue<string>();
        static Queue<Type> classQueue = new Queue<Type>();


        static Queue<Type> classTableQueue = new Queue<Type>();



        /// <summary>
        /// Runner Entry
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static int Main(string[] args)
        {

            #region Input Check and Parsing
            // check required parameters
            // Get Input DLL
            if (!args.Where(m => m == "-f").Any())
            {
                Console.WriteLine("No Input DLL was specified!");
                return 1;
            }
            else
            {
                var dllIdx = Array.IndexOf(args, args.Where(m => m == "-f").Single());
                var path = args[dllIdx + 1];

                // verify DLL file
                if (!File.Exists(path))
                {
                    Console.WriteLine("The specified DLL file could not be found ...");
                    return 404;
                }
                DllPath = path;
            }

            // check for silent flag
            if (args.Where(m => m == "-s").Any())
            {
                runSilent = true;
            }
            else
            {
                runSilent = false;
            }


            // get Output Directory
            if (args.Where(m => m == "-o").Any())
            {
                var dllIdx = Array.IndexOf(args, args.Where(m => m == "-o").Single());
                var path = args[dllIdx + 1];
                output = path;

                if (Directory.Exists(output))
                {
                    if (!runSilent)
                    {
                        Console.WriteLine("The Directory already exists are you sure you want to overwrite the directory? Y:N");
                        string input = Console.ReadLine();
                        if (!input.ToLower().Contains("y"))
                        {
                            Console.WriteLine("Canceled By User ...");
                            return -1;
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(output);
                }
            }

            // Get xml comment file if specified
            if (args.Where(m => m == "-x").Any())
            {
                var dllIdx = Array.IndexOf(args, args.Where(m => m == "-x").Single());
                var path = args[dllIdx + 1];

                if (!File.Exists(path))
                {
                    Console.WriteLine("The specified XML Comment file could not be found ...");
                    return 404;
                }
                useComments = true;
                commentFile = path;
            }



            if (args.Where(m => m == "-h").Any() || args.Where(m => m == "--help").Any())
            {
                // print help text and exit 
                Console.WriteLine("Themis GitLab Document Generator V1\n");
                Console.WriteLine("This is a small utility program used to generate the Markdown files GitLab as documentation for data types marked up with the [GitLabDoc] attributes. Files are automatically generated with association UML diagrams. ");

                Console.WriteLine("ARGUMENTS");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Flag \t Description \t Argument");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("-f \t The location of the DLL file to map\t -f c:\\PATH_TO_MY\\DLL_FILE.dll");
                Console.WriteLine("-s\tRun in silent mode, will automatically overwrite existing data.\t NONE");
                Console.WriteLine("-o\tOutput folder path for generate files.\t -o c:\\OUTPUT\\PATH");
                Console.WriteLine("-x\tUse DotNet Exported XML comments to comment fields and tables. Location of XML file\t -x c:\\PATH_TO_MY\\DLL_FILE.xml");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("The -f and -o arguments must be provided, the -x if omitted will only use [GitLabDoc] meta data to fill in fields. " +
                    "If supplied the comments for methods and functions will be used to in defining fields. " +
                    "If files exist on the system and the -s is used the file are overwritten by default, if the -s flag is omitted you will be prompted to overwrite any data.");

                return 0;
            }



            #endregion Input Check and Parsing

            // Load Assembly
            Assembly asm = Assembly.LoadFrom(DllPath);

            // Loop Types
            Type[] tps = asm.GetTypes();
            foreach (var tp in tps)
            {
                // look for documentation attribute
                var attrb = (GitLabDoc)Attribute.GetCustomAttribute(tp, typeof(GitLabDoc));
                if (attrb != null)
                {
                    //Console.WriteLine($"Building Page for  {tp.Name}");
                    // create the document path
                    if (!Directory.Exists($"{output}/{attrb.DocuemntPath}"))
                    {
                        Directory.CreateDirectory($"{output}/{attrb.DocuemntPath}");
                    }
                    // Build Page
                    //Console.WriteLine($"Writing Navigation for {tp.Name}");
                    string outputText = BuildPageNavigation(tp) + "\n";
                    //Console.WriteLine($"Writing Header for  {tp.Name}");
                    outputText += BuildPageHeader(tp) + "\n";
                    // include comments
                    if (useComments)
                    {
                        //Console.WriteLine($"Writing Class Table for  {tp.Name}");
                        outputText += BuildClassTables(tp) + "\n";
                    }
                    // create class diagram
                    //Console.WriteLine($"Writing Class Diagram for  {tp.Name}");
                    outputText += BuildClassDiagram(tp) + "\n";
                    // write footer
                    //Console.WriteLine($"Writing Footer for  {tp.Name}");
                    outputText += BuildPageFooter(tp) + "\n";
                    // write out file
                    var fileName = $"{output}/{attrb.DocuemntPath}/{attrb.DocumentName}.md";
                    //Console.WriteLine(fileName);
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    using (var stream = File.Create(fileName))
                    {
                        using (var rw = new StreamWriter(stream))
                        {
                            rw.Write(outputText);
                            rw.Flush();
                            rw.Close();
                        }
                        stream.Close();
                    }
                    //Console.WriteLine($"Finished Building Page for  {tp.Name}");
                }
            }
            return 0;
        }



        static string BuildPageNavigation(Type type)
        {
            return string.Empty;
        }




        /// <summary>
        /// Build The Page Header
        /// </summary>
        /// <returns></returns>
        static string BuildPageHeader(Type type)
        {
            string header = string.Empty;
            var attrb = (GitLabDoc)Attribute.GetCustomAttribute(type, typeof(GitLabDoc));
            if (attrb != null)
            {
                if (attrb.Description == null || attrb.Description.Length < 3)
                {
                    header += $"<h3>{type.Name}</h3>\n";
                    header += $"Class Description for <strong>{type.Name}</strong><hr/>\n";
                    header += "<table>\n";
                    header += $"<tr><td> Namespace </td><td> {type.Namespace} </td></tr>\n";
                    header += $"<tr><td> Class Name </td><td> {type.Name} </td></tr>\n";
                    header += $"<tr><td> DLL </td><td> {type.Assembly.FullName} </td></tr>\n";
                    header += $"<tr><td> Base Type </td><td> {type.BaseType} </td></tr>\n";
                    header += "<table>\n";
                }
                else
                {
                    header = attrb.Description;
                }
            }
            return header;
        }


        /// <summary>
        /// Build The Class Table
        /// </summary>
        /// <returns>Table Markup</returns>
        static string BuildClassTables(Type type)
        {


            Dictionary<string, string> typesSummary = new Dictionary<string, string>();
            Dictionary<string, string> paramSummary = new Dictionary<string, string>();
            Dictionary<string, MethodParamaters> methodSummary = new Dictionary<string, MethodParamaters>();

            //XDocument doc = XDocument.Load(commentFile);
            XmlDocument doc = new XmlDocument();
            doc.Load(commentFile);
            var members = doc.ChildNodes[1].ChildNodes[1];

            // parse out dictionaries
            foreach (XmlNode member in members.ChildNodes)
            {
                var name = member.Attributes[0].Value;
                var summary = member.ChildNodes[0].InnerText;




                if (name.StartsWith("T:")) // Type
                {
                    typesSummary.Add(name.Remove(0, 2), summary.Trim());
                }
                else if (name.StartsWith("P:")) // Property
                {
                    paramSummary.Add(name.Remove(0, 2), summary.Trim());
                }
                else if (name.StartsWith("M:")) // Method
                {
                    var dd = new MethodParamaters
                    {
                        Summary = summary.Trim()
                    };

                    foreach (XmlNode f in member.ChildNodes)
                    {
                        if (f.Name == "param")
                        {
                            dd.Paramaters.Add(f.Attributes[0].Value, f.InnerText);
                        }
                    }
                    methodSummary.Add(name.Remove(0, 2), dd);
                }
            }

            var propTable = "<h4>Class Properties</h4>\n<hr/>\n<table style=\"width:100%;\">\n";
            propTable += "<tr>\n";
            propTable += "<th>Property</th>\n";
            propTable += "<th>Type</th>\n";
            propTable += "<th style=\"width:40%\">Summary</th>\n";
            propTable += "</tr>\n";

            int prCount = 0;

            // create property Table
            var properties = type.GetProperties();
            foreach (var prp in properties)
            {
                try
                {
                    // find properties marked for documentation
                    if (prp.GetCustomAttribute(typeof(GitLabDocProperty)) != null)
                    {
                        var fullName = type.FullName + "." + prp.Name;
                        var summ = paramSummary.Where(m => m.Key.Contains(fullName)).Single().Value;
                        var outType = prp.PropertyType.Name;
                        if (Attribute.GetCustomAttribute(prp.PropertyType, typeof(GitLabDoc)) != null)
                        {
                            outType = $"[{prp.PropertyType.Name}]({GenerateLinkFormNamespace(prp.PropertyType)}/{prp.PropertyType.Name}.md)";
                        }

                        if (prp.PropertyType.GetGenericArguments().Length > 0)
                        {
                            outType = $"{prp.PropertyType.Name.Split('`')[0]}[";
                            foreach (var at in prp.PropertyType.GetGenericArguments())
                            {
                                outType += $"[{at.Name}]({GenerateLinkFormNamespace(at)}/{at.Name}.md)";
                            }
                            outType += "]";
                        }

                        propTable += "<tr>\n";
                        propTable += $"<td>{prp.Name}</td>\n";
                        propTable += $"<td>{outType}</td>\n";
                        propTable += $"<td>{summ}</td>\n";
                        propTable += "</tr>\n";
                        prCount++;
                    }
                }
                catch
                {  //  This happens if we load a type with no debug data , mostly external libraries
                }
            }

            propTable += "</table>\n\n";


            var mthTable = "<h4>Class Methods</h4>\n<hr/>\n<table style=\"width:100%;\">\n";
            mthTable += "<tr>\n";
            mthTable += "<th>Method</th>\n";
            mthTable += "<th style=\"width:40%\">Summary</th>\n";
            mthTable += "<th>Return</th>\n";
            mthTable += "<th>Arguments</th>\n";
            mthTable += "</tr>\n";

            int mthCount = 0;
            // create method table
            var methods = type.GetMethods();
            foreach (var mth in methods)
            {
                try
                {
                    // find methods marked for documentation
                    if (mth.GetCustomAttribute(typeof(GitLabDocMethod)) != null)
                    {
                        var fullName = type.FullName + "." + mth.Name;
                        var summ = methodSummary.Where(m => m.Key.Contains(fullName)).Single().Value.Summary;

                        var outArgument = "";
                        var outType = mth.ReturnType.Name;
                        if (Attribute.GetCustomAttribute(mth.ReturnType, typeof(GitLabDoc)) != null)
                        {
                            outType = $"[{mth.ReturnType.Name}]({GenerateLinkFormNamespace(mth.ReturnType)}/{mth.ReturnType.Name}.md)";
                        }

                        if (mth.ReturnType.GetGenericArguments().Length > 0)
                        {
                            outType = $"{mth.ReturnType.Name.Split('`')[0]}[";
                            foreach (var at in mth.ReturnType.GetGenericArguments())
                            {
                                if (Attribute.GetCustomAttribute(at, typeof(GitLabDoc)) != null)
                                {
                                    outType += $"[{at.Name}]({GenerateLinkFormNamespace(at)}/{at.Name}.md)";
                                }
                                else
                                {
                                    outType += at.Name;
                                }
                            }
                            outType += "]";
                        }


                        foreach (var f in mth.GetParameters())
                        {
                            outArgument = "<table style=\"width:100%;\">";
                            outArgument += "<tr>";
                            outArgument += "<th>Name</th>";
                            outArgument += "<th>Type</th>";
                            outArgument += "<th>Summary</th>";
                            outArgument += "</tr>";

                            var prNamet = methodSummary.Where(m => m.Key.Contains(mth.Name)).SingleOrDefault().Value;
                            var prName = prNamet.Paramaters.Where(m => m.Key.Contains(f.Name)).SingleOrDefault().Value;

                            if (f.ParameterType.GetGenericArguments().Length > 0)
                            {
                                var fgh = f.ParameterType.Name.Split('`')[0] + "[";
                                //var info = 
                                foreach (var iny in f.ParameterType.GetGenericArguments())
                                {
                                    if (Attribute.GetCustomAttribute(iny, typeof(GitLabDoc)) != null)
                                    {
                                        fgh += $"[{iny.Name}]({GenerateLinkFormNamespace(iny)}/{iny.Name}.md),";
                                    }
                                    else
                                    {
                                        fgh += $"{iny.Name},";
                                    }

                                }
                                fgh = fgh.Remove(fgh.Length - 1);
                                fgh += "]";

                                outArgument += "<tr>";
                                outArgument += $"<td>{fgh}</td>";
                                outArgument += $"<td>{f.Name}</td>";
                                outArgument += $"<td>{((prName != null) ? prName : "")}</td>";
                                outArgument += "</tr>";
                            }
                            else
                            {
                                if (Attribute.GetCustomAttribute(f.ParameterType, typeof(GitLabDoc)) != null)
                                {
                                    outArgument += "<tr>";
                                    outArgument += $"<td>[{f.ParameterType.Name}]({GenerateLinkFormNamespace(f.ParameterType)}/{f.ParameterType.Name}.md)</td>";
                                    outArgument += $"<td>{f.Name}</td>";
                                    outArgument += $"<td>{((prName != null) ? prName : "")}</td>";
                                    outArgument += "</tr>";
                                }
                                else
                                {
                                    outArgument += "<tr>";
                                    outArgument += $"<td>{f.ParameterType.Name}</td>";
                                    outArgument += $"<td>{f.Name}</td>";
                                    outArgument += $"<td>{((prName != null) ? prName : "")}</td>";
                                    outArgument += "</tr>";
                                }
                            }
                            outArgument += "</table>";
                        }

                        mthTable += "<tr>\n";
                        mthTable += $"<td>{mth.Name}</td>\n";
                        mthTable += $"<td>{summ}</td>\n";
                        mthTable += $"<td>{outType}</td>\n";
                        mthTable += $"<td>{outArgument}</td>\n";
                        mthTable += "</tr>\n";

                        mthCount++;
                    }
                }
                catch
                {  //  This happens if we load a type with no debug data , mostly external libraries
                }
            }

            var ots = "";
            if (prCount > 0)
            {
                ots += propTable;
            }
            if (mthCount > 0)
            {
                ots += mthTable;
            }

            return ots;
        }



        static string GenerateLinkFormNamespace(Type type)
        {
            return "Documents/Generated/" + type.Namespace.Replace('.', '/');
        }


        /// <summary>
        /// Builds The Class Diagram
        /// </summary>
        /// <returns>Diagram Markup</returns>
        static string BuildClassDiagram(Type type)
        {
            string data = WriteType(type);
            Type cls;
            while (classQueue.TryDequeue(out cls))
            {
                data += WriteType(cls);
            }
            string output = "```mermaid\nclassDiagram\n";
            string ot;
            while (pointers.TryDequeue(out ot))
            {
                output += ot;
            }
            output += data + "```\n";
            return output;
        }


        static string WriteType(Type tp)
        {
            // create the class diagram
            string data = "\tclass " + tp.Name + "{\n";
            // Get Properties
            foreach (var prp in tp.GetProperties())
            {
                // check for git lab property 
                Attribute kd = null;
                try
                {
                    kd = Attribute.GetCustomAttribute(prp, typeof(GitLabDocProperty));
                }
                catch (Exception es)
                {
                    Console.WriteLine($">>\n{es.Message}\n" + prp.Name + "\n");
                }

                // if the property is null then don't document
                if (kd != null)
                {
                    Attribute kpD = null;
                    try
                    {
                        kpD = Attribute.GetCustomAttribute(prp.PropertyType, typeof(GitLabDoc));
                    }
                    catch (Exception es)
                    {
                        Console.WriteLine(">>>>" + es.Message);
                    }
                    if (kpD != null)
                    {
                        if (!pointers.Contains($"\t{tp.Name} <-- {prp.PropertyType.Name}\n"))
                        {
                            pointers.Enqueue($"\t{tp.Name} <-- {prp.PropertyType.Name}\n");
                        }
                        classQueue.Enqueue(prp.PropertyType);
                    }

                    if (prp.PropertyType.FullName.Contains("System.Collections.Generic.List") ||
                        prp.PropertyType.FullName.Contains("System.Collections.Generic.Dictionary") ||
                        prp.PropertyType.FullName.Contains("System.Collections.Generic.IEnumberable"))
                    {
                        foreach (var p in prp.PropertyType.GetGenericArguments())
                        {
                            if (p.GetCustomAttribute(typeof(GitLabDoc)) != null)
                            {
                                if (!classQueue.Contains(p))
                                {
                                    if (!pointers.Contains($"\t{tp.Name} <-- {p.Name}\n"))
                                    {
                                        pointers.Enqueue($"\t{tp.Name} <-- {p.Name}\n");
                                    }
                                    classQueue.Enqueue(p);
                                }
                                data += "\t\t+List~" + p.Name + "~ " + prp.Name + "\n";
                            }
                            else
                            {
                                data += "\t\t+List~" + p.Name + "~ " + prp.Name + "\n";
                            }
                        }
                    }
                    else if (prp.PropertyType.FullName.Contains("System.Nullable"))
                    {
                        foreach (var p in prp.PropertyType.GetGenericArguments())
                        {
                            var tpf = Attribute.GetCustomAttribute(p, typeof(GitLabDoc));
                            if (tpf != null)
                            {
                                if (!classQueue.Contains(p))
                                {
                                    if (!pointers.Contains($"\t{tp.Name} <-- {p.Name}\n"))
                                    {
                                        pointers.Enqueue($"\t{tp.Name} <-- {p.Name}\n");
                                    }
                                    classQueue.Enqueue(p);
                                }
                                data += "\t\t+List~" + p.Name + "~? " + prp.Name + "\n";
                            }
                            else
                            {
                                data += "\t\t+List~" + p.Name + "~? " + prp.Name + "\n";
                            }
                        }
                    }
                    else
                    {
                        data += "\t\t+" + prp.PropertyType.Name + " " + prp.Name + "\n";
                    }
                }
            }

            // Get Methods
            foreach (var mth in tp.GetMethods())
            {
                if (mth.GetCustomAttribute(typeof(GitLabDocMethod)) != null)
                {
                    data += $"\t\t +{mth.Name}(";
                    foreach (var ps in mth.GetParameters())
                    {
                        if (Attribute.GetCustomAttribute(ps.ParameterType, typeof(GitLabDoc)) != null)
                        {
                            if (!pointers.Contains($"\t{tp.Name} <-- {ps.ParameterType.Name}\n"))
                            {
                                pointers.Enqueue($"\t{tp.Name} <-- {ps.ParameterType.Name}\n");
                            }
                            if (!classQueue.Contains(ps.ParameterType))
                            {
                                classQueue.Enqueue(ps.ParameterType);
                            }
                        }

                        if (ps.ParameterType.FullName.Contains("System.Collections.Generic.List") ||
                            ps.ParameterType.FullName.Contains("System.Collections.Generic.Dictionary") ||
                            ps.ParameterType.FullName.Contains("System.Collections.Generic.IEnumberable") ||
                            ps.ParameterType.FullName.Contains("System.Collections.IEnumberable"))
                        {
                            foreach (var p in ps.ParameterType.GetGenericArguments())
                            {

                                if (Attribute.GetCustomAttribute(p, typeof(GitLabDoc)) != null)
                                {
                                    if (!classQueue.Contains(p))
                                    {
                                        if (!pointers.Contains($"\t{tp.Name} <-- {p.Name}\n"))
                                        {
                                            pointers.Enqueue($"\t{tp.Name} <-- {p.Name}\n");
                                        }
                                        classQueue.Enqueue(p);
                                    }
                                    data += "\t\t+List~" + p.Name + "~ " + ps.ParameterType.Name + ", ";
                                }
                                else
                                {
                                    data += "\t\t+List~" + p.Name + "~ " + ps.ParameterType.Name + ", ";
                                }
                            }
                        }
                        else if (ps.ParameterType.FullName.Contains("System.Nullable"))
                        {
                            foreach (var p in ps.ParameterType.GetGenericArguments())
                            {

                                if (Attribute.GetCustomAttribute(p, typeof(GitLabDoc)) != null)
                                {
                                    if (!classQueue.Contains(p))
                                    {
                                        if (!pointers.Contains($"\t{tp.Name} <-- {p.Name}\n"))
                                        {
                                            pointers.Enqueue($"\t{tp.Name} <-- {p.Name}\n");
                                        }
                                        classQueue.Enqueue(p);
                                    }
                                    data += "\t\t+" + p.Name + "?  " + ps.ParameterType.Name + ", ";
                                }
                                else
                                {
                                    data += "\t\t+" + p.Name + "? " + ps.ParameterType.Name + ", ";
                                }
                            }
                        }
                        else
                        {
                            data += $"{ps.ParameterType.Name} {ps.Name}, ";
                        }
                    }
                    data = data.Remove(data.Length - 2, 1);
                    data += $") {mth.ReturnType.Name}\n";
                }
            }
            data += "\t}\n";
            return data;
        }


        static string BuildPageFooter(Type type)
        {
            return string.Empty;
        }

    }
}
