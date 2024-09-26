import axios from 'axios';
import './AnimalTable.css';
import { Link } from 'react-router-dom';


function AnimalTable({animals}) { 

    function handleDelete(id) {
      axios.delete('http://localhost:5135/api/Animal' + `/${id}`) 
      .then(response => {
        console.log(response)
      }) 
    }

    return (
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Species</th>
            <th>Age</th>
            <th>Owner Name</th>
            <th>Delete</th>
            <th>Update</th>
            <th>More</th>
          </tr>
        </thead>
        <tbody>
          {animals.map((animal) => {
            return (
              <tr key={animal.id}>
                <td>{animal.name}</td>
                <td>{animal.species}</td>
                <td>{animal.age}</td>
                <td>{animal.owner ? `${animal.owner.firstName} ${animal.owner.lastName}` : "No Owner"}</td>
                <td><button type="button" onClick ={() => handleDelete(animal.id)}>Delete</button></td>
                <td><Link to={`/update/${animal.id}`}><button type="edit">Update</button></Link></td>
                <td><Link to={`/moreInfo/${animal.id}`}><button type="more">+</button></Link></td>
              </tr>
            );
        })}
        </tbody>
      </table>
    );
}

export default AnimalTable;
