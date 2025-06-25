import { useState } from "react";
import type { EndPointsDTO } from "./EndPointsDTO";
import RenderPokemon from "../Resource/Types/POKEMON/RenderPokemon.tsx";
import type { PokemonResponseDTO } from "../Resource/Types/POKEMON/PokemonDTO";

type Props = {
    resourceData: string;
};

export default function AppEndPoints({ resourceData }: Props) {

    const [getEndPoints, setEndPoints] = useState<EndPointsDTO>();
    const [param, setParam] = useState("");
    const [pokeResponse, setPokeResponse] = useState<PokemonResponseDTO | null>(null);

    // Base URL for the .NET backend API
    const baseUrl = import.meta.env.VITE_DOTPOKENETBASEURL;
    if (!baseUrl) {
        throw new Error("API URL is not defined.");
    }

    // Function to handle form submission
    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault(); //Prevent form reload
        Find(param); //Call Find function with param value
        document.getElementById("paramInput")?.focus(); //Focus input after submit
    };

    // Function to find the endpoint for the given resource and parameter
    const Find = (urlParam: string) => {
        if (!baseUrl) {
            console.error("API base URL no está definida.");
            return;
        }

        const normalizedResource = resourceData.toLowerCase();
        const apiEndPoint = `${baseUrl}/api/EndPoint/${normalizedResource}/${encodeURIComponent(urlParam)}`;

        fetch(apiEndPoint)
            .then(async res => {
                if (!res.ok) {
                    const msg = await res.text();
                    throw new Error(`Fetch to .NET BackEnd  → ${res.status}: ${msg}`);
                }
                return res.json() as Promise<EndPointsDTO>;
            })
            .then(data => {
                setEndPoints(data);
                if (!data?.endPoint) {
                    throw new Error("No endPoint in response");
                }

                const endPointFinal = data.endPoint.toLowerCase(); // ← Convert to lowercase
                obtenerDatosDesdeEndPoint(endPointFinal);
            })
            .catch(err => console.error(err));
    };

    // Function to fetch data from the PokeAPI using the endpoint provided by the .NET backend
    const obtenerDatosDesdeEndPoint = async (url: string) => {
        try {

            setPokeResponse(null);// Reset previous response

            const res = await fetch(url);
            if (!res.ok) {
                const msg = await res.text();
                throw new Error(`Fetch to PokeAPI → ${res.status}: ${msg}`);
            }
            const data: PokemonResponseDTO = await res.json();

            setPokeResponse(data);
            console.log("PokeAPI response:", data);
        } catch (err) {
            console.error(err);
        }
    };

    return (
        <>
            <div className="col-lg-12" style={{ margin: 0, padding: "10px" }}>
                {resourceData ?
                    <div className="col-lg-12" style={{ margin: 0, padding: 0 }}>
                        <h4>{resourceData.replace(/_/g, " ")}</h4>
                        <form onSubmit={handleSubmit}>
                            <div className="input-group">
                                <span className="input-group-addon">Name / ID</span>
                                <input
                                    id="paramInput"
                                    value={param}
                                    type="text"
                                    className="form-control"                                    
                                    onChange={e => setParam(e.target.value)}
                                    placeholder="name or id for serch"
                                    pattern="^[a-zA-Z0-9_-]+$"                                    
                                    autoFocus
                                    required
                                    title="Only alphanumeric characters, underscores, and hyphens are allowed."
                                    maxLength={50}
                                    minLength={1} 
                                />
                                <span className="input-group-btn">
                                    <button
                                        type="submit"
                                        className="btn btn-primary"
                                    >
                                        <span className="glyphicon glyphicon-search"></span> Search {resourceData.replace(/_/g, " ")}
                                    </button>
                                </span>
                            </div>
                        </form>
                        {(getEndPoints ? <p className="text-muted"><small>Searching on <strong><a href={getEndPoints.endPoint.toLowerCase()}>{getEndPoints.endPoint.toLowerCase()}</a></strong></small></p> : "")}
                        {pokeResponse && resourceData.toLowerCase() === "pokemon" && (<RenderPokemon pokemonResponse={pokeResponse} />)}
                        {/*pokeResponse ? <pre>{JSON.stringify(pokeResponse, null, 2)}</pre> : ""*/}
                    </div>
                    :
                    ""
                }
            </div >
        </>
    );

}

