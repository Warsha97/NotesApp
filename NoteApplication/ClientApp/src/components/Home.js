import React, { Component } from 'react';
import { RouteComponentProps } from 'react-router';//added
import { Link, NavLink } from 'react-router-dom';  //added
import { NotesTable } from './NotesTable';
import { AddModal } from './AddModal';


export class Home extends Component {
    static displayName = Home.name;

    //state = { notes: [], loading: null };

    //constructor(props) {
    //    super(props);

    //    // TODO: Fetch data from DB and set to local state
    //    // before
    //    this.setState({ loading: true });

    //    // after
    //    this.setState({
    //        loading: false,
    //        notes: fetchNotes || []
    //    })
    //}

    //onEdit = (id, note) => {
    //    // call update reqeut
    //    const notes = this.state.notes;
    //    notes.forEach((n, index) => {
    //        if (n.id === id) {
    //            notes[index] = note;
    //        }
    //    })
    //    this.setState({ notes })
    //}

    //onDelete = (id) => {
    //    // Call delete request
    //    // once success
    //    const notes = this.state.notes.filter((note) => {
    //        return note.id !== id;
    //    });
    //    this.setState({ notes })
    //}

    render() {



        return (

            <div>

                <NotesTable /* notes={notes} onEdit={this.onEdit} onDelete={this.onDelete}*/ />
            </div>

        );
    }
}
