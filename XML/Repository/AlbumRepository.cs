using System;
using XML.Core;
using XML.Model;

namespace XML.Repository
{
    public class AlbumRepository : Repository<Album> , IAlbumRepository
    {
       public AlbumRepository(XMLContext context) : base(context) { }
    }
}
