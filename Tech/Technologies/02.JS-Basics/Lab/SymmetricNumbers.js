"use strict";

function symmetricNumbers(arr) {
    let number = Number(arr[0])

    for (let i = 1; i <= number; i++) {
        isPalindrome(i.toString())
    }

    function isPalindrome(str) {
        let palindrome = true
        for (let i = 0; i < str.length / 2; i++) {
            if (str[i] != str[str.length - i - 1]) {
                palindrome = false
                break;
            }
        }
        if(palindrome){
            console.log(str)
        }
    }
}

symmetricNumbers(['100'])