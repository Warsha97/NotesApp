import React, { Component } from 'react';
import { RouteComponentProps } from 'react-router';//added
import { Link, NavLink } from 'react-router-dom';  //added
import { NotesTable } from './NotesTable';
import { AddModal } from './AddModal';


export class Home extends Component {
    static displayName = Home.name;




    render() {



        return (

            <div>

                <NotesTable />
            </div>

        );
    }
}
