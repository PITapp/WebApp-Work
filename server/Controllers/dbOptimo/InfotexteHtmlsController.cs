using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Query;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace OptimoWork.Controllers.DbOptimo
{
  using Models;
  using Data;
  using Models.DbOptimo;

  [ODataRoutePrefix("odata/dbOptimo/InfotexteHtmls")]
  [Route("mvc/odata/dbOptimo/InfotexteHtmls")]
  public partial class InfotexteHtmlsController : ODataController
  {
    private Data.DbOptimoContext context;

    public InfotexteHtmlsController(Data.DbOptimoContext context)
    {
      this.context = context;
    }
    // GET /odata/DbOptimo/InfotexteHtmls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbOptimo.InfotexteHtml> GetInfotexteHtmls()
    {
      var items = this.context.InfotexteHtmls.AsQueryable<Models.DbOptimo.InfotexteHtml>();
      this.OnInfotexteHtmlsRead(ref items);

      return items;
    }

    partial void OnInfotexteHtmlsRead(ref IQueryable<Models.DbOptimo.InfotexteHtml> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{InfotextID}")]
    public SingleResult<InfotexteHtml> GetInfotexteHtml(int key)
    {
        var items = this.context.InfotexteHtmls.Where(i=>i.InfotextID == key);
        this.OnInfotexteHtmlsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnInfotexteHtmlsGet(ref IQueryable<Models.DbOptimo.InfotexteHtml> items);

    partial void OnInfotexteHtmlDeleted(Models.DbOptimo.InfotexteHtml item);

    [HttpDelete("{InfotextID}")]
    public IActionResult DeleteInfotexteHtml(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.InfotexteHtmls
                .Where(i => i.InfotextID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnInfotexteHtmlDeleted(itemToDelete);
            this.context.InfotexteHtmls.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInfotexteHtmlUpdated(Models.DbOptimo.InfotexteHtml item);

    [HttpPut("{InfotextID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutInfotexteHtml(int key, [FromBody]Models.DbOptimo.InfotexteHtml newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.InfotextID != key))
            {
                return BadRequest();
            }

            this.OnInfotexteHtmlUpdated(newItem);
            this.context.InfotexteHtmls.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.InfotexteHtmls.Where(i => i.InfotextID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{InfotextID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchInfotexteHtml(int key, [FromBody]Delta<Models.DbOptimo.InfotexteHtml> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.InfotexteHtmls.Where(i => i.InfotextID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnInfotexteHtmlUpdated(itemToUpdate);
            this.context.InfotexteHtmls.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.InfotexteHtmls.Where(i => i.InfotextID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnInfotexteHtmlCreated(Models.DbOptimo.InfotexteHtml item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbOptimo.InfotexteHtml item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnInfotexteHtmlCreated(item);
            this.context.InfotexteHtmls.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbOptimo/InfotexteHtmls/{item.InfotextID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
