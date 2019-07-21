import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Label, Input, FormGroup } from 'reactstrap';
import axios from 'axios';
import { NotesTable } from './NotesTable';

export class DeleteModal extends Component {
    constructor(props) {
        super(props);
    };

    state = {

        items: [],
        deleteNoteData: {
            id: '',
            title: '',
            note: '',
            created: '',
            lastUpdated: ''

        },

        deleteNoteModal: false
    }

    toggleDeleteNoteModal() {
        this.setState({
            deleteNoteModal: !this.state.deleteNoteModal
        });
    }
    delete(i, t, n, c, l) {
        //alert(i + t + n + c + l);
        this.setState({
            deleteNoteData: {
                id: i,
                title: t,
                note: n,
                created: c,
                lastUpdated:l

            }
        });

        this.toggleDeleteNoteModal();
    }

    deleteNote() {

        let { id, title, note, created, lastUpdated } = this.state.deleteNoteData;
        axios.delete('api/Notes/' + this.state.deleteNoteData.id, {
            id, title, note, created, lastUpdated
        }).then((response) => {
            console.log(response.data);
        });

        this.toggleDeleteNoteModal();
    }


    render() {
        return (
            <div>

                <Modal isOpen={this.state.deleteNoteModal} toggle={this.toggleDeleteNoteModal} className={this.props.className}>
                    <ModalHeader toggle={this.toggleDeleteNoteModal}>Confirm Delete!</ModalHeader>
                    <ModalBody>
                        {this.state.deleteNoteData.title}
                        Are you sure you want to delete this note?
          </ModalBody>
                    <ModalFooter>
                        <Button color="danger" onClick={this.deleteNote.bind(this)}>Yes,Delete</Button>{' '}
                        <Button color="secondary" onClick={this.toggleDeleteNoteModal.bind(this)}>Cancel</Button>
                    </ModalFooter>
                </Modal>
            </div>

                
            )
    }




}