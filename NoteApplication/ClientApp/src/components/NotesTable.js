import React, { Component } from 'react';
import { Button } from 'reactstrap';
import { Table } from 'reactstrap';
import { AddModal } from './AddModal';

export class NotesTable extends Component {
    state = {
        items: []
    }


    componentWillMount() {

        //const proxyurl = "https://cors-anywhere.herokuapp.com/";
        fetch('api/notes')
            .then(res => res.json())
            .then((data) => {
                this.setState({ items: data })
                console.log(this.state.items)
            })
            .catch(console.log)
    }



    render() {
        return (
            <div>
                <h1>Note Book</h1>
                <AddModal />
                <Table dark>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>Created</th>
                            <th>Last Upadted</th>
                        </tr>
                    </thead>
                    {
                        this.state.items.map(item => (

                            <tr key={item.id}>
                                <td> {item.id}</td>
                                <td> {item.title}</td>
                                <td> {item.note}</td>
                                <td> {item.created}</td>
                                <td> {item.lastUpdated}</td>
                                <td>
                                    <Button color="primary" size="sm" className="mr-2">Edit</Button>
                                    <Button color="danger" size="sm">Delete</Button>
                                </td>

                            </tr>

                        )
                        )
                    }
                </Table>

            </div>


        );
    }
}