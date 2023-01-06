import React from "react";
import {useField} from "formik";
import {Form, Label} from "semantic-ui-react";

interface Props {
    placeholder: string;
    name: string;
    rows: number;
    label?: string;
}

export default function MyTextArea(props: Props){
    // Will tide up the matching fields that are
    // used for the text input in the form:
    const [field, meta] = useField((props.name));

    return(
        <Form.Field error={meta.touched && !!meta.error}>
            <label>{props.label}</label>
            <textarea {...field} {...props}/>
            {meta.touched && meta.error
                ? (<Label basic color='red'>{meta.error}</Label>)
                : null}
        </Form.Field>

    )
}