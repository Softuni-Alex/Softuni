using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleMVC.Routers;
using System.Collections.Generic;
using System.IO;

namespace SoftuniStore.Utilities
{
    public class RouteTable
    {
        public static IEnumerable<Route> Routes
        {
            get
            {
                return new Route[]
                {
                    new Route()
                    {
                      Name = "Jquery JS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/scripts/jquery-3.1.1.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../Resources/scripts/jquery-3.1.1.min.js")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                      new Route()
                    {
                        Name = "Bootstrap JS",
                        Method = RequestMethod.GET,
                        UrlRegex = "/js/bootstrap.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../Resources/js/bootstrap.min.js")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route()
                    {
                      Name = "Bootstrap Map",
                        Method = RequestMethod.GET,
                        UrlRegex = "/css/bootstrap.min.css.map$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../Resources/css/bootstrap.min.css.map")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "Favicon",
                        Method = RequestMethod.GET,
                        UrlRegex = "/favicon.ico$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                Content = File.ReadAllBytes("../../Resources/favicon.ico")
                            };
                            response.Header.ContentType = "image/x-icon";
                            return response;
                        }
                    },
//                    new Route()
//                    {
//                        Name = "Carousel CSS",
//                        Method = RequestMethod.GET,
//                        UrlRegex = "/content/css/carousel.css$",
//                        Callable = (request) =>
//                        {
//                            var response = new HttpResponse()
//                            {
//                                StatusCode = ResponseStatusCode.Ok,
//                                ContentAsUTF8 = File.ReadAllText("../../Content/css/carousel.css")
//                            };
//                            response.Header.ContentType = "text/css";
//                            return response;
//                        }
//                    },
                  
                    new Route()
                    {
                        Name = "Bootstrap css",
                        Method = RequestMethod.GET,
                        UrlRegex = "/css/bootstrap.min.css$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../Resources/css/bootstrap.min.css")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
//                       new Route()
//                    {
//                        Name = "CSS",
//                        Method = RequestMethod.GET,
//                        UrlRegex = "/css/action.css$",
//                        Callable = (request) =>
//                        {
//                            var response = new HttpResponse()
//                            {
//                                StatusCode = ResponseStatusCode.Ok,
//                                ContentAsUTF8 = File.ReadAllText("../../Resources/css/action.css")
//                            };
//                            response.Header.ContentType = "text/css";
//                            return response;
//                        }
//                    },
                    new Route()
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    }
                };
            }
        }
    }
}
