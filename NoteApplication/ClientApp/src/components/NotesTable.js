import React, { Component } from 'react';
import { Button } from 'reactstrap';
import { Table } from 'reactstrap';
import { AddModal } from './AddModal';
import { EditModal } from './EditModal';

export class NotesTable extends Component {
    constructor() {
        super();
        this.handleStateChange = this.handleStateChange.bind(this);
    }
    

   state = {
        items: [],
        editingData: {
            id: '',
            title: '',
            lastUpdated: ''

        }
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



    editNote = (selectedId, selectedTitle, selectedNote, selectedCreated, selectedLastUpdated) => {

        this.refs.editmodal.edit(selectedId, selectedTitle, selectedNote, selectedCreated, selectedLastUpdated);
      
    }


    handleStateChange(value) {
        //event.preventDefault();
        let items = this.state.items;
        items.push(value);
        this.setState({ items: items })
    }
    


    render() {
    
        return (
            <div>
                <h1>Note Book</h1>
                <AddModal handleStateChange={this.handleStateChange} />
                
                <Table dark>
                    <thead>
                        <tr>
                           
                            <th>Title</th>
                            <th>Description</th>
                            <th>Created</th>
                            <th>Last Upadted</th>
                        </tr>
                    </thead>
                    {
                        this.state.items.map(item => (
                            
                            <tr key={item.id}>
                               
                                <td> {item.title}</td>
                                <td> {item.note}</td>
                                <td> {item.created}</td>
                                <td> {item.lastUpdated}</td>
                                <td>

                                    <EditModal ref="editmodal"/>
                                    <Button color="primary" size="sm" className="mr-2" onClick={this.editNote.bind(this, item.id, item.title, item.note, item.created, item.lastUpdated)}>Edit</Button>
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