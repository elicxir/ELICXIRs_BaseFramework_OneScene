# ELICXIRs_BaseFramework_OneScene
unity starter sample for simple app

EBFO:ELICXIRs_BaseFramework_OneScene

Copyright (c) 2022 ELICXIR
Released under the MIT license
https://opensource.org/licenses/mit-license.php

## 概要

1シーンで完結するゲームをUnityで制作するためのベースとなるアセット

以下の仕組みがすでに完成されています。
- ゲームマネージャー
- ゲームのステート切り替えの仕組みと各ステート管理

#### 1シーン完結の設計例:アクションゲーム

シーン上にはメインのアクションゲーム部分を制作して、タイトル画面やリザルト画面はUIのパネルとして作成して必要に応じて呼び出すとよいでしょう。(少々読みにくいとは思いますが2D_ACTの構造を見てみると参考になる部分があるかもしれません。)

#### 1シーン完結の設計例:ノベルゲーム

基本的にUIのパネルに会話ウィンドウやUI、立ち絵などを制作して、必要に応じて呼び出すとよいでしょう。



## 導入方法

Input System Packageを利用しているため以下の手順により有効化してください。

PackageManagerからInputSystemを導入してください。

Project Settings のPlayer / Other Settings / Active Input Handling を Input System Package (New) または BothにすることによりInputSystemを有効化できます。




## 解説



### 用語編
#### gamestate
現在のゲームの状態を表します。Titleならばタイトル画面を、MainGameならばメインのゲーム画面を表します。これは列挙型変数であり、

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

    