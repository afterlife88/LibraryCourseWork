(function () {
    var books = "api/books/";
    var authorsBooks = "api/authors/books/";
    var categoryBooks = "api/categories/books/";

    function getBook(url) {
        $.ajax(
        {
            url: url,
            success: function (bookInfo) {
                var greenCss = 'class="text-success"';
                if (bookInfo.booksLeft < 10) {
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
                popUpDiv.append('<div class="well well-sm"><p ' +greenCss + '>Книг осталось: ' + bookInfo.booksLeft + '</p></div>');
            }
        });
    }
    function getBooksById(url) {
        $.ajax(
        {
            url: url,
            success: function (booksArray) {
                var table = $("#booksTable");
                table.empty();
                table.append('<tr><td><b>#</b></td><td><b>Author</b></td><td><b>Category</b></td><td><b>Book Name</b></td><td><b>Books left</b></td><td><b>Number of pages</b></td></tr>');
                for (var i = 0; i < booksArray.length; i++) {
                    var k = i + 1;
                   var bookId = booksArray[i].bookId;
                    var authorName = booksArray[i].author.firstName;
                    var authorId = booksArray[i].author.authorId;
                    var category = booksArray[i].category.categoryName;
                    var bookName = booksArray[i].bookName;
                    var booksLeft = booksArray[i].booksLeft;
                    var numberOfPages = booksArray[i].numberOfPages;
                    var authorSureName = booksArray[i].author.lastName;
                    var categoryId = booksArray[i].category.categoryId;
                    table.append('<tr><td>' + k + '</td><td>' + '<a class=\"authorSelector\" id=\"' + authorId + '\" href=\"#\">' + authorName + ' ' + authorSureName + '</a>' + '</td><td>' + '<a class=\"categorySelector\" id=\"' + categoryId + '\" href=\"#\">' + category + '</a>' + '</td><td>' + '<a class=\"bookSelector\" data-reveal-id="myModal" data-animation="fadeAndPop" data-animationspeed="300" data-closeonbackgroundclick="true" data-dismissmodalclass="close-reveal-modal" id=\"' + bookId + '\" href=\"#\">' + bookName + '</a>' + '</td><td>' + booksLeft + '</td><td>' + numberOfPages + '</td></tr>');
                }
                $(".bookSelector").click(function (event) {
                    getBook(books + event.target.id);
                });

            }

        });
    }
    function loadAllBooks() {
        $.ajax(
        {
            url: books,
            success: function (listBooks) {
                var table = $("#booksTable");
                table.append('<tr><td><b>#</b></td><td><b>Author</b></td><td><b>Category</b></td><td><b>Book Name</b></td><td><b>Books left</b></td><td><b>Number of pages</b></td></tr>');
                for (var i = 0; i < listBooks.length; i++) {
                    var k = i + 1;
                    var bookId = listBooks[i].bookId;
                    var authorName = listBooks[i].author.firstName;
                    var authorId = listBooks[i].author.authorId;
                    var category = listBooks[i].category.categoryName;
                    var bookName = listBooks[i].bookName;
                    var booksLeft = listBooks[i].booksLeft;
                    var numberOfPages = listBooks[i].numberOfPages;
                    var authorSureName = listBooks[i].author.lastName;
                    var categoryId = listBooks[i].category.categoryId;
                    table.append('<tr><td>' + k + '</td><td>' + '<a class=\"authorSelector\" id=\"' + authorId + '\" href=\"#\">' + authorName + ' ' + authorSureName + '</a>' + '</td><td>' + '<a class=\"categorySelector\" id=\"' + categoryId + '\" href=\"#\">' + category + '</a>' + '</td><td>' + '<a class=\"bookSelector\" data-reveal-id="myModal" data-animation="fadeAndPop" data-animationspeed="300" data-closeonbackgroundclick="true" data-dismissmodalclass="close-reveal-modal" id=\"' + bookId + '\" href=\"#\">' + bookName + '</a>' + '</td><td>' + booksLeft + '</td><td>' + numberOfPages + '</td></tr>');

                }

                $(".authorSelector").click(function (event) {
                    table.fadeOut(100);
                    getBooksById(authorsBooks + event.target.id);
                    table.fadeIn(500);

                });
                $(".categorySelector").click(function (event) {
                    table.fadeOut(100);
                    getBooksById(categoryBooks + event.target.id);
                    table.fadeIn(500);
                });
                $(".bookSelector").click(function (event) {
                    getBook(books + event.target.id);
                });

            }
        });
    }

    loadAllBooks();

})();