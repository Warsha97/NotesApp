import React, { Component } from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Label, Input, FormGroup } from 'reactstrap';
import axios from 'axios';
export class AddModal extends Component {



    state = {
        newNoteModal: false,
        newNoteData: {
            title:'',
            note:'',
            created: new Date().getFullYear() + '-' + (new Date().getMonth() + 1) + '-' + new Date().getDate(),
            lastUpdated: new Date().getFullYear() + '-' + (new Date().getMonth() + 1) + '-' + new Date().getDate()
        }
    }


    toggleNewNoteModal() {
        this.setState({
            newNoteModal: !this.state.newNoteModal
        });
    }

    addNote() {
        //axios.post('api/Notes', this.state.newNoteData).then((response) => {
        //  console.log(response.data)
        //});
        const params = new URLSearchParams();
        params.append('title', this.state.newNoteData.title);
        params.append('note', this.state.newNoteData.note);
        params.append('created', this.state.newNoteData.created);
        params.append('lastUpdated', this.state.newNoteData.lastUpdated);

        axios({
            method: 'post',
            url: 'api/Notes',
            data: {
                title: this.state.newNoteData.title,
                note: this.state.newNoteData.note,
                    created: this.state.newNoteData.created,
                lastUpdated: this.state.newNoteData.lastUpdated
            }
        });
    }



    render() {
        return (

            <div>
                <Button color="success" onClick={this.toggleNewNoteModal.bind(this)}>Add Note</Button>
                <Modal isOpen={this.state.newNoteModal} toggle={this.toggleNewNoteModal.bind(this)} className={this.props.className}>
                    <ModalHeader toggle={this.toggleNewNoteModal.bind(this)}>New Note</ModalHeader>
                    <ModalBody>
                        <FormGroup>
                            <Label for="title">Title</Label>
                            <Input id="title" value={this.state.newNoteData.title} onChange={(e) => {
                                let { newNoteData } = this.state;
                                newNoteData.title = e.target.value;
                                this.setState({ newNoteData });
                            }} />
                        </FormGroup>

                        <FormGroup>
                            <Label for="note">New Note</Label>
                            <Input id="note" value={this.state.newNoteData.note} onChange={(e) => {
                                let { newNoteData } = this.state;
                                newNoteData.note = e.target.value;
                                this.setState({ newNoteData });
                            }} />
                        </FormGroup>
                    </ModalBody>
                    <ModalFooter>
                        <Button color="success" onClick={this.addNote.bind(this)}>Save</Button>{' '}
                        <Button color="secondary" onClick={this.toggleNewNoteModal.bind(this)}>Cancel</Button>
                    </ModalFooter>
                </Modal>
            </div>
        );
    }
} 
