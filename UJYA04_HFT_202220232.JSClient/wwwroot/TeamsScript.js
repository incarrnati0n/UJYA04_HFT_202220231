let teams = [];

getdata();

async function getdata() {
    await fetch('http://localhost:24518/Teams')
          .then(x => x.json())
          .then(y => {
            teams = y;
            //console.log(teams);
            display();
          });
}





function display() {
    teams.forEach(t => {
        document.getElementById('databoard').innerHTML +=
            "<tr><td>" + t.team + "</td><td>"
            + t.teamFoundedYear + "</td><td>"
            + t.teamStadiumName + "</td><td>"
            + t.teamOwner + "</td><td>" + `<button type="button" onclick="Remove(${t.})">` + "</td></tr>";
    });
}

/*Create func buggy ask Ádám when he gets home*/


function remove(id) {
    alert(id);
}


function create() {
    let name = document.getElementById('teamname').value;
    let year = document.getElementById('teamfoundedyear').value;
    let stadium = document.getElementById('teamstadiumname').value;
    let owner = document.getElementById('teamowner').value;
    fetch('http://localhost:24518/Teams', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            { teamName: name, teamFoundedYear: year, teamStadiumName: stadium, teamOwner: owner}),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}