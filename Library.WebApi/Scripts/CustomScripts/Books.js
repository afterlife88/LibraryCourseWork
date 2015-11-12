(function () {
  
    $(document).ready(function () {
      
   
    var baseUri = "api/books";

    function loadAllBooks() {
        $.ajax(
        {
            url: baseUri,
          
            success: function (listBooks) {

                var table = $("#booksTable");
              //  table.empty();
                for (var i = 0; i < listBooks.length; i++) {
                    var bookId = listBooks[i].bookId;
                    var authorName = listBooks[i].author.firstName;
                    var category = listBooks[i].category.categoryName;
                    var bookName = listBooks[i].bookName;
                    var booksLeft = listBooks[i].booksLeft;
                    var numberOfPages = listBooks[i].numberOfPages;
                    var authorSureName = listBooks[i].author.lastName;
                    table.append('<tr><td>' + bookId + '</td><td>' + authorName + ' ' + authorSureName + '</td><td>' + category + '</td><td>' + bookName + '</td><td>' + booksLeft + '</td><td>' + numberOfPages + '</td></tr>');
                }
            }
        });
    }
    loadAllBooks();
    }) })();