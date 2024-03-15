function Table() {
    const data = [
        { id: 1, name: "John Doe", age: 25 },
        { id: 2, name: "Jane Doe", age: 24 },
        { id: 3, name: "John Smith", age: 30 },
    ];

    return (
        <table>
        <thead>
            <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Age</th>
            </tr>
        </thead>
        <tbody>
            {data.map((item) => (
            <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.name}</td>
                <td>{item.age}</td>
            </tr>
            ))}
        </tbody>
        </table>
    );
}

export default Table;