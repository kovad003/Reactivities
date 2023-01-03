import React from "react";
import {Grid} from "semantic-ui-react";
import ActivityList from "./ActivityList";
import ActivityDetails from "../details/ActivityDetails";
import ActivityForm from "../form/ActivityForm";
import {useStore} from "../../../app/stores/store";
import {observer} from "mobx-react-lite";

// export default function ActivitiesDashBoard(props: Props){
export default observer(function ActivityDashBoard(){
    const {activityStore} = useStore();
    const {selectedActivity, editMode} = activityStore; // Destructuring Properties:

    return(
        <Grid>
            <Grid.Column width='10'>
                <ActivityList/>
            </Grid.Column>
            <Grid.Column width='6'>
                {/* <ActivityDetails/> is only loaded if selectedActivity exists (not undefined) */}
                {selectedActivity && !editMode &&
                <ActivityDetails/>}
                {editMode &&
                <ActivityForm/>}
            </Grid.Column>
        </Grid>
    )
})