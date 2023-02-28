namespace Core.Entities
{
    public class WikiPage : BaseEntity
    { 
        /// <summary>
        ///     Name of the wiki page.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Description of the wiki page.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Content of the wiki page.
        /// </summary>
        public string Content { get; set; }
    }
}
