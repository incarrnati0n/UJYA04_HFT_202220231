let manager;
let managername;
let player;
let avg;
let under25;

function getManager() {
    let id = document.getElementById("shnum_input");
    fetch(`http://localhost:24518/stat/ListPlayerByShirtNumber/${id.value}`)
        .then(x => x.json())
        .then(y => {
            manager = y;
            console.log(manager);
            managerDisplay();
        })
}

function averageRating() {
    fetch(`http://localhost:24518/stat/AverageRatingInClub/`)
        .then(x => x.json())
        .then(y => {
            avg = y;
            console.log(avg);
            averageDisplay();
        })
}


function getManagerName() {
    let id = document.getElementById("teamid_input");
    fetch(`http://localhost:24518/stat/ManagerName/${id.value}`)
        .then(x => x.json())
        .then(y => {
            managername = y;
            console.log(managername);
            document.getElementById('resultdiv').innerHTML =
                "<label>The manager's name is: " + managername + "</label>";
            document.getElementById('resultdiv').style.display = 'flex';
        })
}


function highestRated() {
    let age = document.getElementById("age_input").value;
    let teamname = document.getElementById("teamname_input").value;
    fetch(`http://localhost:24518/stat/HighestRatingByTeamAndAge/${age},${teamname}`)
        .then(x => x.json())
        .then(y => {
            player = y;
            console.log(player);
            highestRatedDisplay();
        })
}


function teamWithU25() {
    fetch(`http://localhost:24518/stat/TeamsOfPlayersUnder25`)
        .then(x => x.json())
        .then(y => {
            under25 = y;
            console.log(under25);
            under25Display();
        })
}



function managerDisplay() {
    document.getElementById('resultdiv').innerHTML = "";
    manager.forEach(t => {
        document.getElementById('resultdiv').innerHTML +=
            "<tr><td>" + "The queried manager's name: " + t.managerName  + "</td><td>"
            + "</td></tr>";
    });
}

function averageDisplay() {
    document.getElementById('resultdiv').innerHTML = "";
    avg.forEach(t => {
        document.getElementById('resultdiv').innerHTML +=
            "<tr><td>" + "The teamname:" + t.teamName + "</td><td>" +
            "<tr><td>" + "The rating: " + t.avgRating + "</td></tr>";
    })
}

function highestRatedDisplay() {
    document.getElementById('resultdiv').innerHTML = "";
    player.forEach(t => {
        document.getElementById('resultdiv').innerHTML +=
            "<tr><td>" + "The playername:" + t.playerName + "</td></tr>";
    })
}

function under25Display() {
    document.getElementById('resultdiv').innerHTML = "";
    under25.forEach(t => {
        document.getElementById('resultdiv').innerHTML +=
            "<tr><td>" + "The teamname: " + t + " " + "</td></tr>";
    })
}

