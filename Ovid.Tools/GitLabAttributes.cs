using System;

namespace Ovid.Tools
{
    /// <summary>
    /// Git Lab Document Generator
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
    public class GitLabDoc : Attribute
    {
        private string documentName = "";
        private string docuemntPath = "";
        private string description = "";
        private bool generateDocument = true;
        private Type baseType = null;

        public string DocumentName { get => documentName; }
        public string DocuemntPath { get => docuemntPath; }
        public string Description { get => description; }
        public bool GenerateDocument { get => generateDocument; }
        public Type BaseType { get => baseType; }

        public GitLabDoc(Type type,
            bool generateDocument = true,
            string documentName = "",
            string docuemntPath = "",
            string description = "")
        {
            this.baseType = type;
            this.generateDocument = generateDocument;
            this.documentName = documentName;
            this.docuemntPath = docuemntPath;
            this.description = description;
            if (this.generateDocument &&
                string.IsNullOrWhiteSpace(this.documentName))
            {
                this.documentName = this.baseType.Name;
                if (string.IsNullOrWhiteSpace(this.docuemntPath))
                {
                    this.docuemntPath = this.baseType.Namespace.Replace('.', '/');
                }
            }

            if (this.generateDocument &&
                string.IsNullOrWhiteSpace(this.description))
            {
                this.description = $"Class Description for <strong>{this.baseType.Name}</strong><hr/>\n";
                this.description += "<table>\n";
                this.description += $"<tr><td> Namespace </td><td> {this.baseType.Namespace} </td></tr>\n";
                this.description += $"<tr><td> Class Name </td><td> {this.baseType.Name} </td></tr>\n";
                this.description += $"<tr><td> DLL </td><td> {this.baseType.Assembly.FullName} </td></tr>\n";
                this.description += $"<tr><td> Base Type </td><td> {this.baseType.BaseType} </td></tr>\n";
                this.description += "<table>\n";
            }
        }
    }

    /// <summary>
    /// Used By The GitLab documentation generator to document Properties
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class GitLabDocProperty : Attribute
    {
        private bool overide = false;
        private Type overideType = null;

        public bool Overide { get => overide; }
        public Type OverideType { get => overideType; }


        public GitLabDocProperty(bool overrideType = false, Type type = null)
        {
            this.overide = overrideType;
            this.overideType = type;
        }
    }

    /// <summary>
    /// Used By The GitLab documentation generator to document Methods
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class GitLabDocMethod : Attribute
    {

    }
}
