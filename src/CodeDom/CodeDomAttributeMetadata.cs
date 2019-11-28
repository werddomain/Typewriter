using System.Collections.Generic;
using System.Linq;
using EnvDTE;
using EnvDTE80;
using Typewriter.Metadata.Interfaces;

namespace Typewriter.Metadata.CodeDom
{
    public class CodeDomAttributeMetadata : IAttributeMetadata
    {
        private readonly CodeAttribute2 codeAttribute;
        private readonly string value;

        private CodeDomAttributeMetadata(CodeAttribute2 codeAttribute)
        {
            this.codeAttribute = codeAttribute;
            this.value = codeAttribute.Value;

            if (string.IsNullOrEmpty(this.value))
                this.value = null;
        }
        IEnumerable<KeyValuePair<string, string>> _attributes;
        public IEnumerable<KeyValuePair<string, string>> AttributeArguments
        {
            get
            {
                if (_attributes == null)
                    _attributes = codeAttribute.Children.OfType<CodeAttributeArgument>().Select(o => new KeyValuePair<string, string>(o.Name, o.Value));
                return _attributes;
            }
        }
        public string Name => codeAttribute.Name;
        public string FullName => codeAttribute.FullName;
        public string Value => value;

        public IEnumerable<IAttributeArgumentMetadata> Arguments => throw new System.NotSupportedException();

        internal static IEnumerable<IAttributeMetadata> FromCodeElements(CodeElements codeElements)
        {
            return codeElements.OfType<CodeAttribute2>().Select(a => new CodeDomAttributeMetadata(a));
        }
    }
}