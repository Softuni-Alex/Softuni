const kinveyBaseUrl = "https://baas.kinvey.com/"
const kinveyAppKey = "kid_SJotyduS"
const kinveyAppSecret = "313bcee315914ed3afc6baff74e62786"

function showView(viewName) {
    //Hide all views and show the selected one

    $('main > section').hide();
    $('#' + viewName).show();
}

function showHideMenuLinks() {
    $('#linkHome').show()
    if (sessionStorage.getItem('authToken') == null) {
        //No logged user

        $("#linkLogin").show()
        $("#linkRegister").show()
        $("#linkListBooks").hide()
        $("#linkCreateBooks").hide()
        $("#linkLogout").hide()
    }
    else {
        //We have logged user

        $("#linkLogin").hide()
        $("#linkRegister").hide()
        $("#linkListBooks").show()
        $("#linkCreateBooks").show()
        $("#linkLogout").show()
    }
}

function showInfo(message) {
    $('#infoBox').text(message)
    $('#infoBox').show()
    setTimeout(function () {
        $('#infoBox').fadeOut()
    }, 3000)
}

function showError(errorMsg) {
    $('#errorBox').text("Error: " + errorMsg)
    $('#errorBox').show()
}

$(function () {
    showHideMenuLinks()
    showView()
})

//Bind the navigation menu links
$("#linkHome").click(showHomeView)
$("#linkLogin").click(showLoginView)
$("#linkRegister").click(showRegisterView)
$('#linkListBooks').click(listBooks)
$("#linkCreateBooks").click(showCreateBookView)
$('#linkLogout').click(logout)

//Bind the form submit buttons
$('#formLogin').submit(function (e) {
    e.preventDefault();
    login()
})
$('#formRegister').submit(function (e) {
    e.preventDefault();
    register()
})
$('#formCreateBook').submit(function (e) {
    e.preventDefault();
    createBook()
})
//Attach AJAX "loading" event listener

$(document).on({
    ajaxStart: function () {
        $("#loadingBox").show()
    },
    ajaxStop: function () {
        $("#loadingBox").hide()
    }
})

function showHomeView() {
    showView('viewHome')
}

function showLoginView() {
    showView('viewLogin')
}

function showRegisterView() {
    showView('viewRegister')
}

function showCreateBookView() {
    showView('viewCreateBooks')
}

function login() {
    const kinveyLoginUrl = kinveyBaseUrl + "user/" + kinveyAppKey + "/login"
    const kinveyAuthHeaders = {
        'Authorization': "Basic " + btoa(kinveyAppKey + ":" + kinveyAppSecret),
    };

    let userData = {
        username: $('#loginUser').val(),
        password: $('#loginPass').val()
    }

    let request = {
        method: "POST",
        url: kinveyLoginUrl,
        headers: kinveyAuthHeaders,
        data: userData,
        success: loginSuccess,
        error: handleAjaxError
    }

    $.ajax(request)

    function loginSuccess(response) {
        let userAuth = response._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth)
        showHideMenuLinks()
        listBooks()
        showInfo("Login successful.")
    }
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response)
    if (response.readyState === 0) {
        errorMsg = "Cannot connect due to network error."
    }
    if (response.responseJSON && response.responseJSON.description) {
        errorMsg = response.responseJSON.description
    }
    showError(errorMsg)
}

function register() {
    const kinveyRegisterUrl = kinveyBaseUrl + "user/" + kinveyAppKey + "/"
    const kinveyAuthHeaders = {
        'Authorization': "Basic " + btoa(kinveyAppKey + ":" + kinveyAppSecret),
    }

    let userData = {
        username: $('#registerUser').val(),
        password: $('#registerPass').val()
    }

    let request = {
        method: "POST",
        url: kinveyRegisterUrl,
        headers: kinveyAuthHeaders,
        data: userData,
        success: registerSuccess,
        error: handleAjaxError
    }

    $.ajax(request)

    function registerSuccess(response) {
        let userAuth = response._kmd.authtoken
        sessionStorage.setItem('authToken', userAuth)
        showHideMenuLinks()
        listBooks()
        showInfo('User registration successful.')
    }
}

function listBooks() {
    $('#books').empty()
    showView('viewBooks')

    const kinveyBooksUrl = kinveyBaseUrl + "appdata/" + kinveyAppKey + "/books";
    const kinveyAuthHeaders = {
        'Authorization': "Kinvey " + sessionStorage.getItem('authToken'),
    }

    $.ajax({
        method: "GET",
        url: kinveyBooksUrl,
        headers: kinveyAuthHeaders,
        success: loadBooksSuccess,
        error: handleAjaxError
    })

    function loadBooksSuccess(books) {
        showInfo('Books loaded.')
        if (books.length == 0) {
            $('#books').text('No books in the library.')
        }
        else {
            let booksTable = $('<table>')
                .append($('<tr>').append('<th>Title</th>',
                    '<th>Author</th>', '<th>Description</th>'))

            for (let book of books) {
                booksTable.append($('<tr>').append($('<td>').text(book.title),
                    $('<td>').text(book.author),
                    $('<td>').text(book.description)))
            }
            $('#books').append(booksTable)
        }
    }
}

function createBook() {
    const kinveyBooksUrl = kinveyBaseUrl + "appdata/" + kinveyAppKey + "/books"
    const kinveyAuthHeaders = {
        'Authorization': "Kinvey " + sessionStorage.authToken,
        'Content-Type': "application/json"
    }
    let bookData = {
        title: $('#bookTitle').val(),
        author: $('#bookAuthor').val(),
        description: $('#bookDescription').val()
    }

    $.ajax({
        method: "POST",
        url: kinveyBooksUrl,
        headers: kinveyAuthHeaders,
        data: JSON.stringify(bookData),
        success: createBookSuccess,
        error: handleAjaxError
    })

    function createBookSuccess(response) {
        listBooks()
        showInfo('Book created.')
    }
}

function logout() {
    sessionStorage.clear()
    showHideMenuLinks()
    showView('viewHome')
}

// function addBookComment(bookData, commentText, commentAuthor) {
//     const kinveyBooksUrl = kinveyBaseUrl + "appdata/" + kinveyAppKey + "/books"
//     const kinveyHeaders = {
//         'Authorization': "Kinvey " + sessionStorage.getItem('authToken'),
//         'Content-Type': "application/json"
//     }
//
//     if (!bookData.comments) {
//         bookData.comments = []
//     }
//     bookData.comments.push({text: commentText, author: commentAuthor})
//
//     $.ajax({
//         method: "PUT",
//         url: kinveyBooksUrl + '/' + bookData._id,
//         headers: kinveyHeaders,
//         data: JSON.stringify(bookData),
//         success: addBookCommentSuccess,
//         error: handleAjaxError
//     })
//
//     function addBookCommentSuccess(response) {
//         listBooks()
//         showInfo('Book comment added.')
//     }
//}