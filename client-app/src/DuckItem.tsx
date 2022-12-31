import React from "react";
import {Duck} from "./demo";

interface Props {
    duck: Duck;
}
// export default function DuckItem(props: Props){
export default function DuckItem({duck}: Props) {
    return(
        <div key={duck.name}>
            <span>{duck.name}</span>
            {/*This is not good, statement is executed upon load!
             <button onClick={duck.makeSound(duck.name + 'quack')}></button> */}
            {/* We need an anonymous function */}
            <button onClick={() => duck.makeSound(duck.name + 'quack')}>Make Sound</button>
        </div>
    )
}