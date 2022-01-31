# ELICXIRs_BaseFramework_OneScene
unity starter sample for simple app

EBFO:ELICXIRs_BaseFramework_OneScene

Copyright (c) 2022 ELICXIR
Released under the MIT license
https://opensource.org/licenses/mit-license.php


## お知らせ
複数シーンを扱えるようにした改良版を現在作成中です

https://github.com/elicxir/ELICXIRs_BaseFramework

今後の開発は上のプロジェクトのほうに引き継ぐため上のプロジェクトも確認をお願いします。

## 概要

1シーンで完結するゲームをUnityで制作するためのベースとなるアセット

以下の仕組みがすでに完成されています。
- ゲームマネージャー
- ゲームのステート切り替えの仕組みと各ステート管理

プロジェクトを実行してスペースキーを押すとTitleからGameへの場面の遷移が行われます。フェード機能付きです。

#### 1シーン完結の設計例:アクションゲーム

シーン上にはメインのアクションゲーム部分を制作して、タイトル画面やリザルト画面はUIのパネルとして作成して必要に応じて呼び出すとよいでしょう。

#### 1シーン完結の設計例:ノベルゲーム

基本的にUIのパネルに会話ウィンドウやUI、立ち絵などを制作して、必要に応じて呼び出すとよいでしょう。



## 導入方法

Input System Packageを利用しているため以下の手順により有効化してください。

PackageManagerからInputSystemを導入してください。

Project Settings のPlayer / Other Settings / Active Input Handling を Input System Package (New) または BothにすることによりInputSystemを有効化できます。




## 解説
---
### 用語編
#### gamestate
現在のゲームの状態を表します。Titleならばタイトル画面を、MainGameならばメインのゲーム画面を表します。これは列挙型変数であり、ゲーム内に実装するすべての状態をここに列挙しておく必要があります。

Undefinedを除く各gamestateに対応するGameStateExecuterを作成し、参照を登録する必要があります。

### GameManager
GameManagerはゲーム全体の管理を行うためのスクリプトです。シングルトンであるため一つしか存在しないことが保証されています。

#### StateQueue
StateQueue()関数に次に移行するgamestateを引数として渡してあげることで次のフレームからGameState移行の処理を行うことができます。引数にはgamestateをintにキャストしたものを渡してください。引数を渡さない場合、直前のgamestateに移行します。

同一フレーム内に複数回StateQueue()を実行しても最後に指定した移行のみが行われます。

#### フェード系関数
gamestate移行時の演出に使えるフェード系関数を用意しています。
FadeOut()とFadeIn()関数を主に使えばよいでしょう。引数として時間を渡すことでフェードにかかる時間を調整することができます。

使用例

    public override IEnumerator Finalizer(gamestate after)
    {
        yield return StartCoroutine(GM.FadeOut(0.3f));
    }

---    
### GameStateExecuter
Undefinedを除く各gamestateに対応するGameStateExecuterを作成し、参照を登録する必要があります。

以下の規則に従ってGameStateExecuterを作成してください。
- Undefined以外のgamestateの場合は、クラス名とgamestate名を合致させてください。
- GameStateExecuterはGameManagerの子クラスになっていることが望ましいです。
- GameManagerを右クリックしてSetExecutersを実行することで上記のルールに従っている場合は自動で参照の設定が行われます。

---

#### GameStateExecuter_Panel
GameStateExecuterを拡張してUIのキャンバス機能を用いる際に役に立つ機能を入れたもの。UIのキャンバス機能で作る部分(タイトル画面など)にはこちらを用いるとよいでしょう。

GameStateExecuterを継承しているのでGameStateExecuterの代わりとして用いることができます。
---
#### Miscs
役に立つと思われる以下の機能を入れてあります。
- EnumIndex:配列にEnumの名前を付けてわかりやすくする。
    https://goropocha.hatenablog.com/entry/2021/02/11/232617