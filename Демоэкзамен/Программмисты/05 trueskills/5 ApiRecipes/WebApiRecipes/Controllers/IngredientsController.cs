using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiRecipes.Models;

namespace WebApiRecipes.Controllers
{
    public class IngredientsController : ApiController
    {
        private MyRecipesEntities db = new MyRecipesEntities();

        // GET: api/Ingredients
        public IEnumerable<object> GetIngredients()
        {
            return db.Ingredients.ToList().Select(x => new { x.Name, 
                                                             Price = $"{(double)x.Cost / x.CostForCount:N2} руб." });
        }

        //// GET: api/Ingredients/5
        //[ResponseType(typeof(Ingredient))]
        //public IHttpActionResult GetIngredient(int id)
        //{
        //    Ingredient ingredient = db.Ingredients.Find(id);
        //    if (ingredient == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ingredient);
        //}

        //// PUT: api/Ingredients/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutIngredient(int id, Ingredient ingredient)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != ingredient.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(ingredient).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!IngredientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Ingredients
        //[ResponseType(typeof(Ingredient))]
        //public IHttpActionResult PostIngredient(Ingredient ingredient)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Ingredients.Add(ingredient);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = ingredient.Id }, ingredient);
        //}

        //// DELETE: api/Ingredients/5
        //[ResponseType(typeof(Ingredient))]
        //public IHttpActionResult DeleteIngredient(int id)
        //{
        //    Ingredient ingredient = db.Ingredients.Find(id);
        //    if (ingredient == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Ingredients.Remove(ingredient);
        //    db.SaveChanges();

        //    return Ok(ingredient);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool IngredientExists(int id)
        //{
        //    return db.Ingredients.Count(e => e.Id == id) > 0;
        //}
    }
}