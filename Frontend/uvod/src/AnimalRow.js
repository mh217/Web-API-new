import './AnimalRow.css';

function AnimalRow({ animal }) {
    return (
      <tr>
        <td>{animal.name}</td>
        <td>{animal.species}</td>
        <td>{animal.age}</td>
        <td><button type="button">Delete</button></td>
      </tr>
    );
}

export default AnimalRow;
