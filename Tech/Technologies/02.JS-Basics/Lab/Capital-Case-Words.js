"use strict";

function capitalCaseWords(input) {
    // let splitedInput = input.join(",")
    // let words = splitedInput.split(/\W+/)
    // let empty = words.filter(x=>x.length>0)
    // let upperWords = empty.filter(x=>x.toUpperCase() ==x)
    // console.log(upperWords.join(", "))
    console.log(
        input.join(",")
            .split(/\W+/)
            .filter(x=>x.length>0)
            .filter(x=>x.toUpperCase()==x)
            .join(", "))
}

capitalCaseWords([
    'We start by HTML, CSS, JavaScript, JSON and REST.',
    'Later we touch some PHP, MySQL and SQL.',
    'Later we play with C#, EF, SQL Server and ASP.NET MVC.',
    'Finally, we touch some Java, Hibernate and Spring.MVC.'])