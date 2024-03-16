import React, { useEffect, useState } from 'react';
import axios from 'axios'; 
import { IBowler } from '../interfaces/IBowler';

function Table() {
    const [bowlers, setBowlers] = useState<IBowler[]>([]);

    useEffect(() => {
        // Replace the URL with the correct one for your API
        axios.get('/api/Bowlers')
                .then(response => {
                    setBowlers(response.data);
                })
                .catch(error => console.error("There was an error fetching the bowlers data:", error));
    }, []);

    return (
        <div>
            <br />
            <h2>Bowlers Table</h2>
            <table className="table table-striped">
            <thead>
                <tr>
                <th>Bowler Name</th>
                <th>Team Name</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
                <th>Phone Number</th>
                </tr>
            </thead>
            <tbody>
                {bowlers.map((bowler) => (
                <tr key={bowler.bowlerId}>
                    <td>{`${bowler.bowlerFirstName} ${bowler.bowlerMiddleInit ? bowler.bowlerMiddleInit + ' ' : ''}${bowler.bowlerLastName}`}</td>
                    <td>{bowler.teamName}</td>
                    <td>{bowler.bowlerAddress}</td>
                    <td>{bowler.bowlerCity}</td>
                    <td>{bowler.bowlerState}</td>
                    <td>{bowler.bowlerZip}</td>
                    <td>{bowler.bowlerPhoneNumber}</td>
                </tr>
                ))}
            </tbody>
            </table>
        </div>
    );
}

export default Table;
