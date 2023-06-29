using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module4.Data;
using Module4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoContext>(options => options.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
SeedData.Seed(app);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Sao ko xài ?c ta ??????
//app.MapGroup("/todoitems", Group =>
//{

//});

app.MapGet("/todoitems", async (ToDoContext _context) =>
    await _context.ToDoItems.ToListAsync());

app.MapGet("/todoitems/complete", async (ToDoContext _context) => 
    await _context.ToDoItems.Where(x => x.IsComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, ToDoContext _context) =>
{
    var todoItem = await _context.ToDoItems.FindAsync(id);
    if (todoItem != null)
        return Results.Ok(todoItem);
    else
        return Results.NotFound();
});

app.MapPost("/todoitems", async (ToDoContext _context, ToDoItemRequest request) =>
{
    var TodoItem = new ToDoItem
    {
        Name = request.Name,
        IsComplete = request.IsComplete,
    };
    _context.ToDoItems.Add(TodoItem);
    await _context.SaveChangesAsync();
    return Results.Created($"/todoitems/{TodoItem.Id}", TodoItem);
});

app.MapPut("/todoitems/{id}", async (ToDoContext _context, int id,[FromBody] ToDoItemRequest request) =>
{
    var todoItem = await _context.ToDoItems.FindAsync(id);
    if (todoItem == null)
        return Results.NotFound();
    todoItem.Name = request.Name;
    todoItem.IsComplete = request.IsComplete;
    _context.ToDoItems.Update(todoItem);
    await _context.SaveChangesAsync();
    return Results.Created($"/todoitems/{id}", request);
});

app.MapDelete("/todoitems/{id}", async (int id, ToDoContext _context) => {
    var todoItem = await _context.ToDoItems.FindAsync(id);
    if (todoItem == null)
        return Results.NotFound();
    _context.ToDoItems.Remove(todoItem);
    await _context.SaveChangesAsync();
    return Results.Ok(todoItem);
});

app.Run();

static async Task<IResult> GetAll(ToDoContext _context)
{
    return Results.Ok(await _context.ToDoItems.ToListAsync());
}

static async Task<IResult> Get(ToDoContext _context)
{
    return Results.Ok();
}
