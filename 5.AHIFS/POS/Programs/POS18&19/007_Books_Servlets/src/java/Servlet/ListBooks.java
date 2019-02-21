/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Servlet;

import DataAccess.Database;
import Pojo.Book;
import Pojo.Order;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

/**
 *
 * @author schueler
 */
@WebServlet(name = "ListBooks", urlPatterns = {"/ListBooks"})
public class ListBooks extends HttpServlet {


    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try {
            Database.increaseHits();
            this.verifySession(request);
            if(request.getParameter("Search") != null){
                ArrayList<Book> allBooks = Database.getInstance().selectBooksByAuthorAndTitle(request.getParameter("author"), 
                        request.getParameter("title"));
                writeResponse(request, response, allBooks, null, allBooks.size() + " books found");

            }
            else if (request.getParameter("Back") != null){
                String url = response.encodeRedirectURL((request.getContextPath() + "/Login"));
                response.sendRedirect(url);
            }
            else if (request.getParameter("Order") != null){
                System.out.println("hallo");
                String[] allIds = request.getParameterValues("ckorder");
                if(allIds != null)
                    for(String id : allIds)
                        Database.insert(new Order(Integer.parseInt(id), request.getSession().getAttribute("username").toString()));
                
                ArrayList<Book> orderedBooks = Database.selectOrderedBooksByUsername(request.getSession().getAttribute("username").toString());
                writeResponse(request, response, null, orderedBooks, "books ordered (hits:" + Database.getHits() + ")");

            }
            writeResponse(request, response, null, null, "type in author");

            
        } catch (Exception ex) {
            Logger.getLogger(ListBooks.class.getName()).log(Level.SEVERE, null, ex);
            request.getSession().setAttribute("message", ex.getMessage());
            String url = response.encodeRedirectURL(
            request.getContextPath() + "/Error");
            response.sendRedirect(url);
        }
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        writeResponse(request, response, null, null, "");
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>
    
    private void verifySession(HttpServletRequest request) throws Exception{
        HttpSession session = request.getSession();
        if((session.getAttribute("sessionId") == null) 
                || !session.getId().equals(session.getAttribute("sessionId").toString()))
            throw new Exception("sessionid doesn't fit; probably not coming from login");
    }
    
    private void writeResponse(HttpServletRequest request, HttpServletResponse response, ArrayList<Book> allBooks, ArrayList<Book> orderedBooks, String message) throws IOException{
        String tableString = "";
        String orderString = "";
        if(allBooks != null){
            tableString = this.getHtmlBooksTable(allBooks);
        }
        if(orderedBooks != null){
            orderString = this.getHtmlOrdersTable(orderedBooks);
        }
        try (PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>\n" +
                        "<html lang=\"en\" dir=\"ltr\">\n" +
                        "  <head>\n" +
                        "    <meta charset=\"utf-8\">\n" +
                        "    <title>Insert new Book</title>\n" +
                        "    <style media=\"screen\">\n" +
                        "      @import url(https://fonts.googleapis.com/css?family=Roboto:300);\n" +
                        "\n" +
                        "      .login-page {\n" +
                        "        width: 360px;\n" +
                        "        padding: 8% 0 0;\n" +
                        "        margin: auto;\n" +
                        "      }\n" +
                        "      .form {\n" +
                        "        position: relative;\n" +
                        "        z-index: 1;\n" +
                        "        background: #FFFFFF;\n" +
                        "        max-width: 360px;\n" +
                        "        margin: 0 auto 100px;\n" +
                        "        padding: 45px;\n" +
                        "        text-align: center;\n" +
                        "        box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);\n" +
                        "      }\n" +
                        "      .form input {\n" +
                        "        font-family: \"Roboto\", sans-serif;\n" +
                        "        outline: 0;\n" +
                        "        background: #f2f2f2;\n" +
                        "        width: 100%;\n" +
                        "        border: 0;\n" +
                        "        margin: 0 0 15px;\n" +
                        "        padding: 15px;\n" +
                        "        box-sizing: border-box;\n" +
                        "        font-size: 14px;\n" +
                        "      }\n" +
                        "      .form input[type=submit]  {\n" +
                        "        font-family: \"Roboto\", sans-serif;\n" +
                        "        text-transform: uppercase;\n" +
                        "        outline: 0;\n" +
                        "        background: #43A047;\n" +
                        "        width: 100%;\n" +
                        "        border: 0;\n" +
                        "        padding: 15px;\n" +
                        "        color: #FFFFFF;\n" +
                        "        font-size: 14px;\n" +
                        "        -webkit-transition: all 0.3 ease;\n" +
                        "        transition: all 0.3 ease;\n" +
                        "        cursor: pointer;\n" +
                        "      }\n" +
                        "      .form input[type=submit]:hover,.form button:active,.form button:focus {\n" +
                        "        background: #43A047;\n" +
                        "      }\n" +
                        "      .form .message {\n" +
                        "        margin: 15px 0 0;\n" +
                        "        color: #b3b3b3;\n" +
                        "        font-size: 12px;\n" +
                        "      }\n" +
                        "      .form .message a {\n" +
                        "        color: #4CAF50;\n" +
                        "        text-decoration: none;\n" +
                        "      }\n" +
                        "      .form .register-form {\n" +
                        "        display: none;\n" +
                        "      }\n" +
                        "      .container {\n" +
                        "        position: relative;\n" +
                        "        z-index: 1;\n" +
                        "        max-width: 300px;\n" +
                        "        margin: 0 auto;\n" +
                        "      }\n" +
                        "      .container:before, .container:after {\n" +
                        "        content: \"\";\n" +
                        "        display: block;\n" +
                        "        clear: both;\n" +
                        "      }\n" +
                        "      .container .info {\n" +
                        "        margin: 50px auto;\n" +
                        "        text-align: center;\n" +
                        "      }\n" +
                        "      .container .info h1 {\n" +
                        "        margin: 0 0 15px;\n" +
                        "        padding: 0;\n" +
                        "        font-size: 36px;\n" +
                        "        font-weight: 300;\n" +
                        "        color: #1a1a1a;\n" +
                        "      }\n" +
                        "      .container .info span {\n" +
                        "        color: #4d4d4d;\n" +
                        "        font-size: 12px;\n" +
                        "      }\n" +
                        "      .container .info span a {\n" +
                        "        color: #000000;\n" +
                        "        text-decoration: none;\n" +
                        "      }\n" +
                        "      .container .info span .fa {\n" +
                        "        color: #EF3B3A;\n" +
                        "      }\n" +
                        "      body {\n" +
                        "        background: #76b852; /* fallback for old browsers */\n" +
                        "        background: -webkit-linear-gradient(right, #76b852, #8DC26F);\n" +
                        "        background: -moz-linear-gradient(right, #76b852, #8DC26F);\n" +
                        "        background: -o-linear-gradient(right, #76b852, #8DC26F);\n" +
                        "        background: linear-gradient(to left, #76b852, #8DC26F);\n" +
                        "        font-family: \"Roboto\", sans-serif;\n" +
                        "        -webkit-font-smoothing: antialiased;\n" +
                        "        -moz-osx-font-smoothing: grayscale;\n" +
                        "      }\n" +
                        "    </style>\n" +
                        "  </head>\n" +
                        "  <body>\n" +
                        "    <div class=\"login-page\">\n" + 
                        "      <div class=\"form\">\n" +
                        "    <h1>List Books for user '" + request.getSession().getAttribute("username") + "'</h1>\n" + 
                        "        <form class=\"login-form\" method=\"GET\" action=\"" + request.getContextPath() + "/ListBooks\">\n" +
                                tableString +
                                orderString +
                        "          <input type=\"text\" name=\"author\" placeholder=\"author\"/>\n" +
                        "          <input type=\"text\" name=\"title\" placeholder=\"title\"/>\n" +
                        "          <input id=\"formButton\" type=\"submit\" name=\"Search\" value=\"Search\"/>\n" +
                        "          <input id=\"formButton\" type=\"submit\" name=\"Order\" value=\"Order\"/>\n" +
                        "          <input id=\"formButton\" type=\"submit\" name=\"Back\" value=\"Back\"/>\n" +
                        "           <p class=\"message\">" + message + "</p>\n" +
                        "        </form>\n" +
                        "      </div>\n" +
                        "    </div>\n" +
                        "  </body>\n" +
                        "</html>");
         }
    }
    
    private String getHtmlBooksTable(ArrayList<Book> books) {
        StringBuilder html = new StringBuilder();
        html.append("<table>");
        html.append("<tr><th>Order</th><th>ID</th><th>Author</th><th>Title</th></tr>");
        
        books.forEach((b) -> {
            html.append("<tr>")
                    .append("<td><input type=\"checkbox\" name=\"ckorder\" value=\"" + b.getId() + "\"></td>")
                    .append("<td>").append(b.getId()).append("</td>")
                    .append("<td>").append(b.getAuthor()).append("</td>")
                    .append("<td>").append(b.getTitle()).append("</td>")
                    .append("</tr>");
        });
        html.append("</table><br>");
        
        return html.toString();
    }

    private String getHtmlOrdersTable(ArrayList<Book> allOrders) {
        StringBuilder html = new StringBuilder();
        html.append("<table>");
        html.append("<h2>found Orders:</h2>");
        html.append("<tr><th>author</th><th>title</th></tr>");
        
        allOrders.forEach((b) -> {
            html.append("<tr>")
                    .append("<td>").append(b.getAuthor()).append("</td>")
                    .append("<td>").append(b.getTitle()).append("</td>")
                    .append("</tr>");
        });
        html.append("</table><br>");
        
        return html.toString();    
    }
}
