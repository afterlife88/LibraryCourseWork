(function () {
    var books = "api/books/";
    var authorsBooks = "api/authors/books/";
    var categoryBooks = "api/categories/books/";
    var orderAscBooks = "api/books/orderdsc";
    var oderAscAuthors = "api/authors/orderasc";
    var oderAscCategory = "api/category/orderasc";
    // var orderAscAuthors
    function getBook(url) {
        $.ajax(
        {
            url: url,
            success: function (bookInfo) {
                var greenCss = 'class="text-success"';
                if (bookInfo.booksLeft < 15) {
                    greenCss = 'class="text-danger"';
                }
                var popUpDiv = $("#myModal");
                popUpDiv.find('*').not('.close-reveal-modal').remove();
                popUpDiv.append("<h1>" + bookInfo.bookName + "</h1>");
                popUpDiv.append('<p class="lead">' + bookInfo.author.firstName + " " + bookInfo.author.lastName + '</p>');
                popUpDiv.append('<p class="text-info">Оригинальное название: <b>' + bookInfo.originalNameOfBook + '</b></p>');
                popUpDiv.append('<p class="text-info"> Год издания: ' + bookInfo.yearOfBook + '</p>');
                popUpDiv.append('<p class="text-primary">Количество страниц: ' + bookInfo.numberOfPages + '</p>');
                popUpDiv.append('<p class="text-primary"> ISBN: ' + bookInfo.isbn + '</p>');
                popUpDiv.append('<p>' + bookInfo.bookDescription + '</p>');
                popUpDiv.append('<div class="well well-sm"><p ' + greenCss + '>Книг осталось: ' + bookInfo.booksLeft + '</p></div>');
            }
        });
    }
    function getBooksByUrl(url) {
        $.ajax(
        {
            url: url,
            success: function (booksArray) {
                var table = $("#booksTable");
                table.empty();
                table.append('<tr><td><b>#</b></td><td><b><a class=\"authorDsc\" id=\"' + oderAscAuthors + '\" href=\"#\">Author</a></b></td><td><b>Category</b></td><td><b><a class=\"booksAsc\" id=\"' + orderAscBooks + '\" href=\"#\">Book Name</a></b></td><td><b>Books left</b></td></tr>');
                for (var i = 0; i < booksArray.length; i++) {
                    var k = i + 1;
                    var bookId = booksArray[i].bookId;
                    var authorName = booksArray[i].author.firstName;
                    var authorId = booksArray[i].author.authorId;
                    var category = booksArray[i].category.categoryName;
                    var bookName = booksArray[i].bookName;
                    var booksLeft = booksArray[i].booksLeft;
                    var authorSureName = booksArray[i].author.lastName;
                    var categoryId = booksArray[i].category.categoryId;
                    table.append('<tr><td>' + k + '</td><td>' + '<a class=\"authorSelector\" id=\"' + authorId + '\" href=\"#\">' + authorName + ' ' + authorSureName + '</a>' + '</td><td>' + '<a class=\"categorySelector\" id=\"' + categoryId + '\" href=\"#\">' + category + '</a>' + '</td><td>' + '<a class=\"bookSelector\" data-reveal-id="myModal" data-animation="fadeAndPop" data-animationspeed="300" data-closeonbackgroundclick="true" data-dismissmodalclass="close-reveal-modal" id=\"' + bookId + '\" href=\"#\">' + bookName + '</a>' + '</td><td>' + booksLeft + '</td></tr>');
                }
                $(".authorSelector").click(function (event) {
                    table.fadeOut(100);
                    getBooksByUrl(authorsBooks + event.target.id);
                    table.fadeIn(500);

                });
                $(".categorySelector").click(function (event) {
                    table.fadeOut(100);
                    getBooksByUrl(categoryBooks + event.target.id);
                    table.fadeIn(500);
                });
                $(".bookSelector").click(function (event) {
                    getBook(books + event.target.id);
                });

                $(".booksAsc").click(function (event) {
                    table.fadeOut(100);
                    getBooksByUrl(event.target.id);
                    table.fadeIn(500);
                });
                $(".authorDsc").click(function (event) {
                    table.fadeOut(100);
                    getBooksByUrl(event.target.id);
                    table.fadeIn(500);
                });
            }
        });
    }
    getBooksByUrl(books);

})();