using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using gamesLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using gamesLibrary.Service;

namespace gamesLibrary.Controllers
{


    [Authorize]
    public class GamesController : Controller
    {
        private readonly IUserService _userService;
        string connectionString = gamesLibrary.Properties.Resources.ConnectionString;

        List<Games> videoGames = new List<Games>();

        public GamesController(IUserService userService)
        {
            _userService = userService;
        }


        public ActionResult Index(string option, string search, string sortOrder)
        {

            DataTable dataTable = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                //query for getting all the games in the games table
                sqlcon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Games", sqlcon);
                dataAdapter.Fill(dataTable);

            }
            var title = dataTable.Rows[1]["Title"];
            //checking if their is a result and then adding to a games list
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];
                int review = (dr["Review"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["Review"]); //checking if database value is null
                string textReview = (dr["TextReview"] == DBNull.Value) ? "" : dr["TextReview"].ToString();
                if (dr["Review"] != DBNull.Value & dr["TextReview"] != DBNull.Value)
                {
                    videoGames.Add(new Games
                    {
                        gameID = Convert.ToInt32(dr["gameID"]),
                        Title = dr["Title"].ToString().ToUpper(),
                        Genre = dr["Genre"].ToString().ToUpper(),
                        ReleaseYear = Convert.ToInt32(dr["ReleaseYear"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Review = Convert.ToInt32(dr["Review"]),
                        TextReview = dr["TextReview"].ToString()
                    });
                } else if (dr["Review"] == DBNull.Value)
                {
                    videoGames.Add(new Games
                    {
                        gameID = Convert.ToInt32(dr["gameID"]),
                        Title = dr["Title"].ToString().ToUpper(),
                        Genre = dr["Genre"].ToString().ToUpper(),
                        ReleaseYear = Convert.ToInt32(dr["ReleaseYear"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Review = 0,
                        TextReview = dr["TextReview"].ToString()
                    });
                }
                else if (dr["TextReview"] == DBNull.Value)
                {
                    videoGames.Add(new Games
                    {
                        gameID = Convert.ToInt32(dr["gameID"]),
                        Title = dr["Title"].ToString().ToUpper(),
                        Genre = dr["Genre"].ToString().ToUpper(),
                        ReleaseYear = Convert.ToInt32(dr["ReleaseYear"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Review = Convert.ToInt32(dr["Review"]),
                        TextReview = ""
                    });
                }

            }

            var game = from g in videoGames select g;
            
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.RankSortParm = sortOrder == "Rank" ? "rank_desc" : "Rank";

            if (!String.IsNullOrEmpty(search)) //checking if search box has been used
            {

                if (option == "Title")//checking options and performing search
                {
                    game = game.Where(g => g.Title.Contains(search.ToUpper()));
                    Console.WriteLine(search);

                } else if (option == "Genre")
                {
                    game = game.Where(g => g.Genre.Contains(search.ToUpper()));
                    Console.WriteLine(search);
                } else if (option == "ReleaseYear")
                {

                    //var datesearch = Convert.ToDateTime(search);
                    game = game.Where(g => g.ReleaseYear.Equals(Convert.ToInt32(search)));

                }
                else if (option == "Price")
                { 
                    game = game.Where(g => g.Price.Equals(Convert.ToDecimal(search)));
                }
            }
            //sorts games based on Title, Rank, or Year Released in desc and ascending order
            switch (sortOrder)
            {
                case "name_desc":
                    game = game.OrderByDescending(g => g.Title);
                    break;
                case "Date":
                    game = game.OrderBy(g => g.ReleaseYear);
                    break;
                case "date_desc":
                    game = game.OrderByDescending(g => g.ReleaseYear);
                    break;
                case "rank_desc":
                    game = game.OrderByDescending(g => g.Review);
                    break;
                case "Rank":
                    game = game.OrderBy(g => g.Review);
                    break;
                default:
                    game = game.OrderByDescending(g => g.Review);
                    break;
            }
            //Console.WriteLine("Game: ", dataTable.Rows[0]["gameID"]);
            return View(game.ToList());
        }

        //Gets games in users table
        [HttpGet]
        // GET: GamesController
        public ActionResult GetGames(String sortOrder)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.RankSortParm = sortOrder == "Rank" ? "rank_desc" : "Rank";

            DataTable dataTable = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                //performing query to find the relevant games that the user has added to their table 
                sqlcon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("Select Games.gameID, Games.Title, Games.Genre, Games.Price, Games.ReleaseYear, Users_Games.userReview, Users_Games.userTextReview " +
                    "From((Users_Games Inner Join AspNetUsers On Users_Games.userID = AspNetUsers.Id)Inner Join Games On Users_Games.gameID = Games.gameID)" +
                    "Where Users_Games.userID = @userID; ", sqlcon);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@userID", _userService.GetUserId());
                dataAdapter.Fill(dataTable);
            }


            //converting to games list
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];
                int review = (dr["userReview"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["userReview"]);
                string textReview = (dr["userTextReview"] == DBNull.Value) ? "" : dr["userTextReview"].ToString();
                if (dr["userReview"] != DBNull.Value & dr["userTextReview"] != DBNull.Value)
                {
                    videoGames.Add(new Games
                    {
                        gameID = Convert.ToInt32(dr["gameID"]),
                        Title = dr["Title"].ToString().ToUpper(),
                        Genre = dr["Genre"].ToString().ToUpper(),
                        ReleaseYear = Convert.ToInt32(dr["ReleaseYear"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Review = Convert.ToInt32(dr["userReview"]),
                        TextReview = dr["userTextReview"].ToString()
                    });
                }
                else if (dr["userReview"] == DBNull.Value)
                {
                    videoGames.Add(new Games
                    {
                        gameID = Convert.ToInt32(dr["gameID"]),
                        Title = dr["Title"].ToString().ToUpper(),
                        Genre = dr["Genre"].ToString().ToUpper(),
                        ReleaseYear = Convert.ToInt32(dr["ReleaseYear"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Review = 0,
                        TextReview = dr["userTextReview"].ToString()
                    });
                }
                else if (dr["userTextReview"] == DBNull.Value)
                {
                    videoGames.Add(new Games
                    {
                        gameID = Convert.ToInt32(dr["gameID"]),
                        Title = dr["Title"].ToString().ToUpper(),
                        Genre = dr["Genre"].ToString().ToUpper(),
                        ReleaseYear = Convert.ToInt32(dr["ReleaseYear"]),
                        Price = Convert.ToDecimal(dr["Price"]),
                        Review = Convert.ToInt32(dr["userReview"]),
                        TextReview = ""
                    });
                }
            }
            var game = from g in videoGames select g;
            switch (sortOrder)
            {
                case "name_desc":
                    game = game.OrderByDescending(g => g.Title);
                    break;
                case "Date":
                    game = game.OrderBy(g => g.ReleaseYear);
                    break;
                case "date_desc":
                    game = game.OrderByDescending(g => g.ReleaseYear);
                    break;
                case "rank_desc":
                    game = game.OrderByDescending(g => g.Review);
                    break;
                case "Rank":
                    game = game.OrderBy(g => g.Review);
                    break;
                default:
                    game = game.OrderByDescending(g => g.Review);
                    break;
            }
            return View(game.ToList()) ;
            
        }

        // GET: GamesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GamesController/Create
        public ActionResult CreateGame(int id)
        {
            Games gameModel = new Games();
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * From Games Where Games.gameID = @gameID", sqlcon);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@gameID", id);
                dataAdapter.Fill(dataTable);
            }

            if (dataTable.Rows.Count == 1)
            {
                gameModel.gameID = Convert.ToInt32(dataTable.Rows[0][0]);
                gameModel.Title = dataTable.Rows[0][1].ToString().ToUpper();
                gameModel.Genre = dataTable.Rows[0][2].ToString().ToUpper();
                gameModel.ReleaseYear = Convert.ToInt32(dataTable.Rows[0][3]);
                gameModel.Price = Convert.ToInt32(dataTable.Rows[0][4]);
            }
            return View(gameModel);

        }

        // POST: GamesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGame(Games gameModel, int id)
        {
            //Add a game from the library into the users library
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();

                string checkGameQuery = "Select * From Users_Games Where userID = @userID AND gameID = @gameID;";

                SqlCommand checkCommand = new SqlCommand(checkGameQuery, sqlcon);
                checkCommand.Parameters.AddWithValue("@userID", _userService.GetUserId());
                checkCommand.Parameters.AddWithValue("@gameID", id);
                Console.WriteLine("Game Model: ", gameModel);
                DataTable dt = new DataTable();
                var gameExists = checkCommand.ExecuteScalar();
                int intGameEx = Convert.ToInt32(gameExists);
                if (intGameEx == 0)
                {
                    Console.WriteLine("Game not in table");
                    string query = "insert into Users_Games values(@userID, @gameID, @userReview, @userTextReview);";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);

                    cmd.Parameters.AddWithValue("@userID", _userService.GetUserId());
                    cmd.Parameters.AddWithValue("@gameID", id);
                    cmd.Parameters.AddWithValue("@userReview", DBNull.Value);
                    cmd.Parameters.AddWithValue("@userTextReview", "Not Reviewed by User");


                    cmd.ExecuteNonQuery();
                    return RedirectToAction("GetGames");
                } else
                {
                    Console.WriteLine("Game in table");
                    Console.WriteLine("title: ", gameModel.Title);

                }

            }

            return RedirectToAction("Index");
        }

        // GET: GamesController/Edit/5
        public ActionResult Edit(int id)
        {
            
            Games gameModel = new Games();
            DataTable dateTable = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {

                sqlCon.Open();
                string query = "Select Games.gameID, Games.Title, Users_Games.userReview, Users_Games.userTextReview " +
                    "From((Users_Games Inner Join AspNetUsers On Users_Games.userID = AspNetUsers.Id) Inner Join Games On Users_Games.gameID = Games.gameID) " +
                    "Where Users_Games.userID = @userID AND Users_Games.gameID = @gameID; ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlCon);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@userID", _userService.GetUserId());
                dataAdapter.SelectCommand.Parameters.AddWithValue("@gameID", id);
                dataAdapter.Fill(dateTable);
            }

            if (dateTable.Rows.Count == 1)
            {
                gameModel.gameID = Convert.ToInt32(dateTable.Rows[0][0]);
                gameModel.Title = dateTable.Rows[0][1].ToString();
                if (dateTable.Rows[0][2] == DBNull.Value)
                {
                    gameModel.Review = 0;
                    gameModel.TextReview = dateTable.Rows[0][3].ToString();
                    return View(gameModel);
                }
                else if (dateTable.Rows[0][3] == DBNull.Value)
                {
                    gameModel.TextReview = "";
                    gameModel.Review = Convert.ToInt32(dateTable.Rows[0][2]);
                    return View(gameModel);
                }
                else if (dateTable.Rows[0][3] == DBNull.Value & dateTable.Rows[0][2] == DBNull.Value)
                {
                    gameModel.TextReview = "";
                    gameModel.Review = 0;
                    return View(gameModel);
                }
                else
                {
                    gameModel.Review = Convert.ToInt32(dateTable.Rows[0][2]);
                    gameModel.TextReview = dateTable.Rows[0][3].ToString();
                }
                return View(gameModel);
            }
            else
            {
                return RedirectToAction("GetGames");
            }

        }

        // POST: GamesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Games gameModel, int id)
        {
            //Updating game by allowing user to add a text review and a number review between 1 and 5
            if (ModelState.IsValid) //checking if form requirements have been met
            {

                using (SqlConnection SqlCon = new SqlConnection(connectionString))
                {
                    SqlCon.Open();
                    String updateQuery = "Update Users_Games Set Users_Games.userReview = @review, Users_Games.userTextReview = @textReview " +
                        "From((Users_Games Inner Join AspNetUsers On Users_Games.userID = AspNetUsers.Id) Inner Join Games On Users_Games.gameID = Games.gameID)" +
                        "Where Users_Games.userID = @userId and Users_Games.gameID = @gameID; ";
                    SqlCommand cmd = new SqlCommand(updateQuery, SqlCon);

                    cmd.Parameters.AddWithValue("@gameID", id);
                    cmd.Parameters.AddWithValue("@review", gameModel.Review);

                    cmd.Parameters.AddWithValue("@userID", _userService.GetUserId());
                    if (gameModel.TextReview == null)
                    {
                        cmd.Parameters.AddWithValue("@textReview", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@textReview", gameModel.TextReview);
                    }
                    if (gameModel.Review < 0 || gameModel.Review > 5)
                    {

                    }


                    Console.WriteLine("Updating Game", gameModel.Title);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("GetGames");
            }
            return View(gameModel);
        }

        // GET: GamesController/Delete/5
        public ActionResult Delete(int id)
        {
            //Removing game from users library
            using (SqlConnection SqlCon = new SqlConnection(connectionString))
            {
                SqlCon.Open();
                String updateQuery = "Delete From Users_Games Where gameID = @gameID And userId = @userID";
                SqlCommand cmd = new SqlCommand(updateQuery, SqlCon);

                cmd.Parameters.AddWithValue("@gameID", id);
                cmd.Parameters.AddWithValue("@userID", _userService.GetUserId());
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("GetGames");
        }

        // POST: GamesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    
}
