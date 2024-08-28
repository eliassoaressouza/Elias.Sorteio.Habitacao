import { Pessoa } from "../../models/pessoa";
type GridPessoa = {
    listaPessoa: Pessoa[];
}
export function PessoaLista(props: GridPessoa) {
    return (
        <table className="table">
            <thead>
                <tr>
                    <th scope="col">CPF</th>
                    <th scope="col">Nome</th>
                </tr>
            </thead>
            <tbody>
                {props && props.listaPessoa.map(p =>
                    <tr key={p.cpf} >
                        <td>{p.cpf}</td>
                        <td>{p.nome}</td>
                    </tr>
                )
                }
            </tbody>
        </table>
    );
}