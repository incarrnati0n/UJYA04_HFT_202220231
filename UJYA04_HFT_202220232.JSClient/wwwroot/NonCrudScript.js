let manager;
let managername;
let player;
let avg

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

// ez is fos
function highestRated() {
    let age = document.getElementById("age_input");
    let teamname = document.getElementById("teamname_input");
    fetch(`http://localhost:24518/stat/HighestRatingByTeamAndAge/${age},${teamname}`)
        .then(x => x.json())
        .then(y => {
            player = y;
            console.log(player);
            document.getElementById('resultdiv').innerHTML = "";
            document.getElementById('resultdiv').innerHTML =
                "<label>" + "Playername: " + player.playerName + "</label>"; 
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
