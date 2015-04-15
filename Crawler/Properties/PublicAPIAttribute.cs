namespace Crawler.Properties
{
    using System;

    /// <summary>
    /// This attribute is intended to mark publicly available API
    /// which should not be removed and so is treated as used
    /// </summary>
    [MeansImplicitUse]
    public sealed class PublicAPIAttribute : Attribute
    {
        public PublicAPIAttribute() { }
        public PublicAPIAttribute([NotNull] string comment)
        {
            this.Comment = comment;
        }

        [NotNull] public string Comment { get; private set; }
    }
}