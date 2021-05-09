var hotList = [];
var questionsInHotList = 3;
var displayedQuestion;
var numberOfQuestions;
var nextQuestion = 1;


function init() {
    for (var i = 0; i < questionsInHotList; i++) {
        hotList[i] = {
            question: {},
            goodAnswers:0
        }
     
    }
    //kező kérdéslista letöltés
    for (var i = 0; i < questionsInHotList; i++) {
        kérdésBetöltés(nextQuestion, i);
        nextQuestion++;

    }

    //Kérdések száma
    fetch("questions/count")
        .then(result => result.text())
        .then(n => { numberOfQuestions = parseInt(n) })

    //előre hátra gombok
    document.getElementById("előre_gomb").addEventListener("click", előre);
    document.getElementById("vissza_gomb").addEventListener("click", hátra );

}

function kérdésBetöltés(questionNumber, destination) {
    fetch('/question/${questionNumber}')
        .then(result => {
            if (result.ok) {
                console.error('Hibás letöltés: ${result.status}')

                return null;
            }
            else {
                return result.json();
            }
        })
        .then(q => {
            hotList[destination].question = q;
            hotList[destination].goodAnswers = 0;
            console.log('A ${questionNumber}.kérdés letöltésre került a hotlist ${destination} helyére);
            if (displayedQuestion === undefined && destination === null) {
                displayedQuestion = 0;
                kérdésMegjelenítés();

            }
                })
} 
function kérdésMegjelenítés() {
    let kérdés = hotList[displayedQuestion].question;
    document.getElementById("kérdés szöveg").innerText = kérdés.questionText;
    document.getElementById("válasz1").innerText = kérdés.answer1;
    document.getElementById("válasz2").innerText = kérdés.answer2;
    document.getElementById("válasz3").innerText = kérdés.answer3;

    if (kérdés.image) {
        document.getElementById("kép").src = kérdés.image;
        document.getElementById("kép").style.display = "block";

    }
    else {
        document.getElementById("kép").style.display = "none";
    }


}

document.addEventListener("DOMContentLoaded", init)

function előre() {
    displayedQuestion++;
    if (displayedQuestion === questionsInHotList) displayedQuestion = 0;
    kérdésMegjelenítés();
}
function hátra() { 
    displayedQuestion--;
    if (displayedQuestion < 0) displayedQuestion = questionsInHotList - 1;
    kérdésMegjelenítés();
}

function választás(n) {
    let kérdés = hotList[displayedQuestion].question;
    if (n === kérdés.correctAnswer) {
        document.getElementById("válasz"+n).classList.add("jó")


    }
    else {
        document.getElementById("válasz" + n).classList.add("rossz")
        document.getElementById("válasz" + kérdés.correctAnswer).classList.add("rossz")
    }
}